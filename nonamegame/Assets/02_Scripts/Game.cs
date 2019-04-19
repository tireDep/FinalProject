using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Scene change
using UnityStandardAssets.ImageEffects; // Blur

public class Game : MonoBehaviour
{
    /*
     게임 진행 관련 스크립트
     - 카메라 이동 함수
     - 일시정지 On/Off 함수
     */

    public static bool isPause = false;    // 일시정지 변수
    void Start()
    {
        Time.timeScale = 1; // 재시작시 일시정지 방지 
        Camera.main.GetComponent<Blur>().enabled = false;   // 블러 해제
        isPause = false;
        canvasUI.enabled = true;
        pauseUI.enabled = false;
        // 일시정지 관련 설정
    }   // Start()

    void Update()
    {
        if (!isPause)
        {
            CheckPlayTime();
        }
        Move();
        CheckPause();
    }   // Update()

    private void Move() // 카메라 이동
    {
        Camera.main.transform.Translate(5f * Time.deltaTime, 0f, 0f);
    }   //  Move()

    float isTime = 0.0f;    // 경과시간
    float checkTime = 0.1f; //  생성시간 !수정될 수 있는 값!
    int checkCount = 0;
    private void CheckPlayTime()    // 플레이시간 몇 초 지나갔는지 확인
    {
        isTime += Time.deltaTime;
        if (isTime > checkTime)    // 0.1초 지날 때마다 생성
        {
            GetComponent<Map>().CreateMap();
            checkCount++;
            isTime = 0.0f;
        }
    }   // CheckPlayTime() 
    
    public Canvas canvasUI;
    public Canvas pauseUI;
    public void CheckPause()    // pause상태 검사
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                PauseOn();
            }
            else
            {
                PauseOff();
            }
        }
    }   // CheckPause()

    public void PauseOn()   // 일시정지 설정
    {
        Time.timeScale = 0;
        isPause = true;
        canvasUI.enabled = false;
        pauseUI.enabled = true;
        Camera.main.GetComponent<Blur>().enabled = true;
        // auido.Pause();
    }   // PauseOn()

    public void PauseOff()  // 일시정지 해제
    {
        Time.timeScale = 1;
        isPause = false;
        canvasUI.enabled = true;
        pauseUI.enabled = false;
        Camera.main.GetComponent<Blur>().enabled = false;
        // auido.Play();
    }   //  PauseOff()

}   // Game Class
