using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class UIEventWindow : UIBase
{
    // SO�� Event�� ���� ������ �޾ƿ´�.
    // �ش� ������ ���ؼ� UI�� �����Ѵ�.

    // SO�� ��ư

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


