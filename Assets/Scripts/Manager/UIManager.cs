using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public UIManager()
    {
        Prefabs = new Dictionary<UIName, GameObject>();
    }


    public Dictionary<UIName, GameObject> Prefabs { get; private set; }

    public void LoadUIPrefabs()
    {
        var gameObjects = Resources.LoadAll<GameObject>("Prefabs/UI");

        foreach (var go in gameObjects)
        {
            if (Enum.TryParse(go.name, out UIName _uiName))
            {
                Prefabs.Add(_uiName, go);
            }
            
        }
    }

    public void OpenUI()
    {
        //오브젝트 풀에 해당 UI가 존재하는지 확인하고 존재한다면 그 UI를 불러오고 아니라면 새로 생성한다.
    }

    public void CloseUI() 
    {
        //UI를 setfalse해서 오브젝트 풀에 쳐박는다.
    }
}