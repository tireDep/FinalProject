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

    public void GoToStart() // 시작화면 전환
    {
        SceneManager.LoadScene("01_Start");
    }   // GoToStart()

    public void GoToStage() // 스테이지 전환
    {
        SceneManager.LoadScene("02_Stage");
    }   //  GoToStage() 

    public void GameEnd()   // 게임 종료
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
    }   // GameEnd()

    // 스테이지 선택 관련
    public void GoToSt01()
    {
        SceneManager.LoadScene("03_Play_1");
    }   // GoToSt01()

    public void GoToSt02()
    {
        SceneManager.LoadScene("03_Play_2");
    }   // GoToSt02()

    public void GoToSt03()
    {
        SceneManager.LoadScene("03_Play_3");
    }   // GoToSt03()

    public void GoToSt04()
    {
        SceneManager.LoadScene("03_Play_4");
    }   // GoToSt04()

    public void GoToSt05()
    {
        SceneManager.LoadScene("03_Play_5");
    }   // GoToSt05()

}   // Interface Class
