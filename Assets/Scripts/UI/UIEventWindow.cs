using System.Collections.Generic;
using TMPro;

public class UIEventWindow : UIBase
{
    // SO로 Event에 대한 정보를 받아온다.
    // 해당 정보를 통해서 UI를 수정한다.

    // SO에 버튼

    public EventInfoSO eventInfoSO;
    public TextMeshProUGUI eventName;
    public TextMeshProUGUI eventInfo;
    public List<UIButton> selectButtonList = new List<UIButton>();

    public void Init(EventInfoSO so)
    {
        eventInfoSO = so;

        eventName.text = eventInfoSO.eventName;
        eventInfo.text = eventInfoSO.eventInfo;

        for (int i =0; i< selectButtonList.Count; i++)
        {
            if (i >= eventInfoSO.selectEventInfo.Count)
            {
                selectButtonList[i].gameObject.SetActive(false);
                continue;
            }
            selectButtonList[i].gameObject.SetActive(true);
            selectButtonList[i].OnClick += OnClicked;
            selectButtonList[i].GetComponentInChildren<TextMeshProUGUI>().text = eventInfoSO.selectEventInfo[i];
        }
    }

    public void OnClicked()
    {
        UIManager.Instance.CloseUI();
    }
}


