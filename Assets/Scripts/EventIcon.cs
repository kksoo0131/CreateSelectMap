using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.FilePathAttribute;

public class EventIcon : MonoBehaviour
{
    public LocationInfo info;
    public EventInfoSO eventInfoSO;
    public GameObject Check;
    private void Awake()
    {
        GetComponentInChildren<UIButton>().OnClick += CheckIndex;
    }
    public void CheckIndex()
    {
        LocationInfo currentInfo = GameManager.Instance.CurrentLocationInfo;
        if (currentInfo == null)
        {
            if (info.Floor == 0)
            {
                EnterEvent();
            }
        }
        else if (currentInfo.Floor + 1 == info.Floor)
        {
            int difference = currentInfo.Index - info.Index;

            difference = difference > 0 ? difference : -difference;

            if(difference < 2)
            {
                EnterEvent();
            }

        }
    }

    public void EnterEvent()
    {
        GameManager.Instance.CurrentLocationInfo = info;
        GameObject go = UIManager.Instance.OpenUI(UIName.UIEventWindow);
        Check.SetActive(true);
        switch (info.EventType)
        {
            case EventType.Battle:
                go.GetComponent<UIEventWindow>().Init(eventInfoSO);
                break;
            case EventType.Chest:
                go.GetComponent<UIEventWindow>().Init(eventInfoSO);
                break;
            case EventType.Potion:
                go.GetComponent<UIEventWindow>().Init(eventInfoSO);
                break;
            case EventType.Elite:
                go.GetComponent<UIEventWindow>().Init(eventInfoSO);
                break;
            default:
                break;
        }
    }
}
