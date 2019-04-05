using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Scene change

public class Interface : MonoBehaviour
{

    public void GameStart() // 게임화면 이동
    {
        SceneManager.LoadScene("MainGame");
    }

    public void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        // 유니티 에디터 종료
#elif UNITY_WEBPLAYER
        Application.OpenURL("http://google.com");
        // 웹 종료 -> 구글화면
#else
        Application.Quit();
        // 프로그램 종료
#endif
    }

    public void Continue()
    {
        bool getPause = GameObject.Find("isPause").GetComponent<Player>();
        Time.timeScale = 1;
        getPause = true;

    }
 
}
