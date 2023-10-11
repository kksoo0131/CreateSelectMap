using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Transform UIRoot;
    public LocationInfo CurrentLocationInfo;
    public Player player;
    
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

    private void GameInit()
    {
        UIManager.Instance.OpenUI(UIName.UIMap);
        player = new Player();
        player.baseStat = stat;
        player.StatInit();
    }

}
