using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Scene change

public class Interface : MonoBehaviour
{
    /*
     화면 이동, 종료 관련 스크립트
     - 화면이동 함수
     - 종료관련 함수
     */

    public void GameStart() // 게임화면 이동
    {
        SceneManager.LoadScene("MainGame");
    }   //  GameStart()

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
    }   // GameQuit()

    public void ReturnMain()    // 메인으로 
    {
        SceneManager.LoadScene("GameStart");
    }   // ReturnMain()

}   // Interface Class
