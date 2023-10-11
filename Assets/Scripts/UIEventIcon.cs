using UnityEngine;
public class UIEventIcon : UIButton
{
    public LocationInfo info;
    public EventInfoSO eventInfoSO;
    public GameObject Check;
    private void Awake()
    {
        OnClick += CheckIndex;
    }
    private void CheckIndex()
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

    private void EnterEvent()
    {
        GameManager.Instance.CurrentLocationInfo = info;
        GameObject go = UIManager.Instance.OpenUI(UIName.UIEventWindow);
        Check.SetActive(true);
        go.GetComponent<UIEventWindow>().Init(eventInfoSO);
    }
}
