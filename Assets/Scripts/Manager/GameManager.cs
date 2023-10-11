
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


    // ���� ������ �������ְ�.

    // ���� �� ���� �´� �������� ������ ����������� �Ѿ��.



}
