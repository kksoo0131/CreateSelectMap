using UnityEngine;

public class Player
{
    public CharacterStatSO baseStat;
    public CharacterStatSO CurrentStat { get; private set; }

    private void Awake()
    {
    }

    public void StatInit()
    {
        CurrentStat = new CharacterStatSO(baseStat);
    }
}