using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public UIManager()
    {
        Prefabs = new Dictionary<UIName, UIBase>();
        UIPopUpStack = new Stack<GameObject>();
        LoadUIPrefabs();
    }


    public Dictionary<UIName, UIBase> Prefabs { get; private set; }
    public Stack<GameObject> UIPopUpStack { get; private set; }
    
    

    public void LoadUIPrefabs()
    {
        var gameObjects = Resources.LoadAll<GameObject>("Prefabs/UI");

        foreach (var go in gameObjects)
        {
            if (Enum.TryParse(go.name, out UIName _uiName))
            {
                Prefabs.Add(_uiName, go.GetComponent<UIBase>());
            }
            
        }
    }

    public GameObject OpenUI(UIName name)
    {
        GameObject go = GameObject.Instantiate(Prefabs[name].gameObject, GameManager.Instance.UIRoot);

        UIPopUpStack.Push(go);
        //오브젝트 풀에 해당 UI가 존재하는지 확인하고 존재한다면 그 UI를 불러오고 아니라면 새로 생성한다.

        return go;
    }

    public GameObject OpenUI(UIName name, Transform parent)
    {
        GameObject go = GameObject.Instantiate(Prefabs[name].gameObject, parent);
        
        UIPopUpStack.Push(go);
        //오브젝트 풀에 해당 UI가 존재하는지 확인하고 존재한다면 그 UI를 불러오고 아니라면 새로 생성한다.

        return go;
    }

    public void CloseUI() 
    {
        GameObject.Destroy(UIPopUpStack.Pop());
        //UI를 setfalse해서 오브젝트 풀에 쳐박는다.
    }
}