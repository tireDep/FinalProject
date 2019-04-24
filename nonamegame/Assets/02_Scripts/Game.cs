using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Scene change
using UnityStandardAssets.ImageEffects; // Blur
using UnityEngine.UI;   // UI

public class Game : MonoBehaviour
{
    /*
     게임 진행 관련 스크립트
     - 카메라 이동 함수
     - 일시정지 On/Off 함수
     - 게임 UI 설정
     - 점수 계산
     */

    public static bool isPause = false;    // 일시정지 변수

    private static int maxScore = 1000000;  // 최고점수
    public static int playerScore;  // 플레이어 점수
    public Text playerScorText; // 점수 UI

    void Start()
    {
        Time.timeScale = 1; // 재시작시 일시정지 방지 
        Camera.main.GetComponent<Blur>().enabled = false;   // 블러 해제
        isPause = false;
        canvasUI.enabled = true;
        pauseUI.enabled = false;
        // 일시정지 관련 설정

        playerScore = maxScore; 
        checkHitCount = 0;
        playerHitCount = 0;
        // 점수 관련 초기화
    }   // Start()

    void Update()
    {
        if (Player.isDead)
        {
            SceneManager.LoadScene("GameOver");
        }   // 죽음 여부 판별

        if (!isPause)
        {
            CheckPlayTime();
        }   // 일시정지 여부 판별

        UpdateGUI();
        Move();
        CheckPause();
    }   // Update()

    private int checkHitCount;  // 부딪힘 & 점수차감 체크
    int playerHitCount; // Player.cs에서 변수 받아옴
    void UpdateGUI()    // UI setting
    {
        playerHitCount = Player.playerHitCount; // 부딪힘 횟수 받아옴
        playerScorText.text = playerScore.ToString();
        if (checkHitCount<playerHitCount) // 장애물에 부딪힐 경우 점수 차감
        {
            playerScore -= playerHitCount * 2 * 100;
            checkHitCount++;
        }
    }   // UpdateGUI()

    private void Move() // 카메라 이동
    {
        Camera.main.transform.Translate(10f * Time.deltaTime, 0f, 0f);
    }   //  Move()

    float isTime = 0.0f;    // 경과시간
    float checkTime = 0.05f; //  생성시간 !수정될 수 있는 값!
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
        Time.timeScale = 0; // 정지
        isPause = true;
        canvasUI.enabled = false;
        pauseUI.enabled = true;
        Camera.main.GetComponent<Blur>().enabled = true;    // 카메라 블러 효과
        Audio.audioSource.Pause();  // 오디오 정지
    }   // PauseOn()

    public void PauseOff()  // 일시정지 해제
    {
        Time.timeScale = 1;
        isPause = false;
        canvasUI.enabled = true;
        pauseUI.enabled = false;
        Camera.main.GetComponent<Blur>().enabled = false;
        Audio.audioSource.Play();
    }   //  PauseOff()

}   // Game Class
