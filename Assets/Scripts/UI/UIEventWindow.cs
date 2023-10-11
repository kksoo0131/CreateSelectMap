using System.Collections.Generic;
using TMPro;

public class UIEventWindow : UIBase
{
    // SO�� Event�� ���� ������ �޾ƿ´�.
    // �ش� ������ ���ؼ� UI�� �����Ѵ�.

    // SO�� ��ư

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


