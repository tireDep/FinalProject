﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Scene change

public class Game : MonoBehaviour
{
    private bool isPause = false;    // 일시정지 변수
    void Start()
    {
        Time.timeScale = 1; // 이거 안하면 재시작때 렉걸림
        isPause = false;
        canvasUI.enabled = true;
        pauseUI.enabled = false;
        // pasue UI Setting
    }   // Start()

    void Update()
    {
        if (!isPause)
        {
            CheckPlayTime();
        }
        CheckPause();
    }   // Update()

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
        /*if(checkCount==5)
        {
            DeleteMap();
            checkCount = 0;
        }*/ // 일케하면 구멍뚤린지형 나옴.. 근데 왜 안떨어지는 거지...?
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
        //Camera.main.GetComponent<Blur>().enabled = true;
    }   // PauseOn()

    public void PauseOff()  // 일시정지 해제
    {
        Time.timeScale = 1;
        isPause = false;
        canvasUI.enabled = true;
        pauseUI.enabled = false;
        //Camera.main.GetComponent<Blur>().enabled = false;
    }   //  PauseOff()

}   // Class()
