using UnityEngine;

[CreateAssetMenu(fileName = "DamagedEvent", menuName = "Data/EventFuncData/DamagedEvent", order = 2)]
public class DamagedEventSO : EventFuncSO
{
    public int damage;
    public override void OnUse()
    {
        GameManager.Instance.player.CurrentStat.Hp -= damage;
        UIManager.Instance.CloseUI();
    }
}