
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Transform UIRoot;
    public LocationInfo CurrentLocationInfo;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        GameInit();
    }

    private void GameInit()
    {
        UIManager.Instance.OpenUI(UIName.UIMap);
    }


    // 현재 층수를 가지고있고.

    // 현재 층 수에 맞는 아이콘을 누르면 전투페이즈로 넘어간다.



}
