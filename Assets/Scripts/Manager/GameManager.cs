using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Transform UIRoot;
    public LocationInfo CurrentLocationInfo;
    public Player player;
    public bool isRun;
    
    public CharacterStatSO stat; // temp
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        GameInit();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (!isRun) return;

        if (player.CurrentStat.Hp <= 0)
        {
            UIManager.Instance.OpenUI(UIName.UIGameOver);
            isRun = false;

        }
        if (CurrentLocationInfo != null && CurrentLocationInfo.Floor >= 9)
        {
            UIManager.Instance.OpenUI(UIName.UIClear);
            isRun = false;
        }
    }

    private void GameInit()
    {
        isRun = true;
        UIManager.Instance.OpenUI(UIName.UIMap);
        player = new Player
        {
            baseStat = stat
        };
        player.StatInit();
    }

}
