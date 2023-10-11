using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStartMenu : UIBase
{
    public UIButton StartBtn;
    public UIButton EndBtn;
    private void Awake()
    {
        StartBtn.OnClick += GameStart;
        EndBtn.OnClick += GameEnd;
    }

    public void GameStart()
    {
        SceneManager.LoadScene("GameScene");

    }
    public void GameEnd() 
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Apllication.Quit();
        #endif
    }

}
