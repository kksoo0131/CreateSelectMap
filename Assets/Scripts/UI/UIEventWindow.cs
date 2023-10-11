using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class UIEventWindow : UIBase
{
    // SO로 Event에 대한 정보를 받아온다.
    // 해당 정보를 통해서 UI를 수정한다.

    // SO에 버튼

    public TextMeshProUGUI eventName;
    public TextMeshProUGUI eventInfo;
    public List<UIButton> selectButtonList = new List<UIButton>();

    public void Init(EventInfoSO so)
    {
        eventName.text = so.eventName;
        eventInfo.text = so.eventInfo;

        for (int i =0; i< selectButtonList.Count; i++)
        {
            if (i >= so.selectEventInfo.Count)
            {
                selectButtonList[i].gameObject.SetActive(false);
                continue;
            }
            selectButtonList[i].gameObject.SetActive(true);
            selectButtonList[i].OnClick += OnClicked;
            selectButtonList[i].GetComponentInChildren<TextMeshProUGUI>().text = so.selectEventInfo[i];
        }
    }

    public void OnClicked()
    {
        UIManager.Instance.CloseUI();
    }
}


