using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStatData", menuName = "Data/StatData", order = 1)]

public class CharacterStatSO : ScriptableObject
{
    public int maxHp;
    public int maxMp;
    public int Hp;
    public int Mp;
    public int Attack;
    public int Gold;
    
    public CharacterStatSO(CharacterStatSO baseStat)
    {
        Copy(baseStat);
    }

    public void Copy(CharacterStatSO baseStat)
    {
        maxHp = baseStat.maxMp;
        maxMp = baseStat.maxMp;
        Hp = baseStat.Hp;
        Mp = baseStat.Mp;
        Attack = baseStat.Attack;
        Gold = baseStat.Gold;
    }
    public float GetPercentageHp()
    {
        return (float)Hp / maxHp;
    }
    public float GetPercentageMp()
    {
        return (float)Mp / maxMp;
    }
}