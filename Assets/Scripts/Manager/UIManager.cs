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
        //������Ʈ Ǯ�� �ش� UI�� �����ϴ��� Ȯ���ϰ� �����Ѵٸ� �� UI�� �ҷ����� �ƴ϶�� ���� �����Ѵ�.
    }

    public void CloseUI() 
    {
        //UI�� setfalse�ؼ� ������Ʈ Ǯ�� �Ĺڴ´�.
    }
}