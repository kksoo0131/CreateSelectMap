using UnityEngine;

[CreateAssetMenu(fileName = "RunEvent", menuName = "Data/EventFuncData/RunEvent", order = 3)]
public class RunEventSO : EventFuncSO
{
    public int useMp;
    public override void OnUse()
    {
        GameManager.Instance.player.CurrentStat.Mp -= useMp;
        UIManager.Instance.CloseUI();
    }
}