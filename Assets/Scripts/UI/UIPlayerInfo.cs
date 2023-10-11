using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPlayerInfo : UIBase
{
    public Image Hp;
    public Image Mp;
    public TextMeshProUGUI Attack;
    public TextMeshProUGUI Gold;


    public CharacterStatSO playerStat;

    private void Start()
    {
        playerStat = GameManager.Instance.player.CurrentStat;
    }


    private void Update()
    {
        Hp.fillAmount = playerStat.GetPercentageHp();
        Mp.fillAmount = playerStat.GetPercentageMp();
        Attack.text = playerStat.Attack.ToString();
        Gold.text = playerStat.Gold.ToString();
    }
}
