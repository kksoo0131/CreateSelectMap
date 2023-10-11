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
        //������Ʈ Ǯ�� �ش� UI�� �����ϴ��� Ȯ���ϰ� �����Ѵٸ� �� UI�� �ҷ����� �ƴ϶�� ���� �����Ѵ�.

        return go;
    }

    public GameObject OpenUI(UIName name, Transform parent)
    {
        GameObject go = GameObject.Instantiate(Prefabs[name].gameObject, parent);
        
        UIPopUpStack.Push(go);
        //������Ʈ Ǯ�� �ش� UI�� �����ϴ��� Ȯ���ϰ� �����Ѵٸ� �� UI�� �ҷ����� �ƴ϶�� ���� �����Ѵ�.

        return go;
    }

    public void CloseUI() 
    {
        GameObject.Destroy(UIPopUpStack.Pop());
        //UI�� setfalse�ؼ� ������Ʈ Ǯ�� �Ĺڴ´�.
    }
}