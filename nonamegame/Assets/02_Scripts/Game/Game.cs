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

    public static bool isPause;    // 일시정지 변수

    public static int maxScore = 1000000;  // 최고점수
    public static int playerScore;  // 플레이어 점수
    public Text playerScoreText; // 점수 UI

    public Text bsCntText;  // 화면삭제 UI

    public Vector3 lastCheckPointPos;   // 플레이어 위치
    public Vector3 lastCheckCamera;  // 카메라 위치
    public float lastCheckAudio;   //  음악진행사항
    // 체크포인트 관련

    public static int _bsCnt;  // 화면 지울 수 있는 횟수

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

        _moveSpeed = DataManager.moveSpeed;
        _bsCnt = DataManager.bsCnt;
        // 변수 값 초기화

    }   // Start()

    void Update()
    {
        if(Audio.isAudioFin)
        {
            GoToResultScene();
        }   // 음악 종료 시 페이드효과&게임 결과 화면 출력

        UpdateGUI();
        Move();
        CheckPause();
    }   // Update()

    public static int checkHitCount;  // 부딪힘 & 점수차감 체크
    int playerHitCount; // Player.cs에서 변수 받아옴
    void UpdateGUI()    // UI setting
    {
        playerHitCount = Player.playerHitCount; // 부딪힘 횟수 받아옴
        playerScoreText.text = playerScore.ToString();
        if (checkHitCount<playerHitCount) // 장애물에 부딪힐 경우 점수 차감
        {
            playerScore -= playerHitCount * 2 * 100;
            checkHitCount++;
        }

        if(_bsCnt<=0)   // BSCnt 갯수 출력
        {
            bsCntText.text = "NOPE :(";
        }
        else
        {
            bsCntText.text =  "Remove :)\n" + _bsCnt.ToString();
        }

    }   // UpdateGUI()

    // 모바일 버튼 함수들
    public void MobileJumpBtn()
    {
        Player.PlayerJump();
    }   // JumpBtn()

    public void MobileConvertBtn()
    {
        Player.CheckPlayerPos();
    }   // ConvertBtn()

    public void MobileBsBtn()
    {
        BlueScreenOn();
    }   // BsBtn()

    private float _moveSpeed;   // 이동속도
    private void Move() // 카메라 이동
    {
        Camera.main.transform.Translate(_moveSpeed * Time.deltaTime, 0f, 0f);
    }   //  Move()
    
    public Canvas canvasUI;
    public Canvas pauseUI;
    public void CheckPause()    // pause상태 검사
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetPause();
        }
    }   // CheckPause()

    public void SetPause()  // pause상태 변경
    {
        if (Time.timeScale == 1)
        {
            PauseOn();
        }
        else
        {
            PauseOff();
        }
    }   // SetPause()
    
    void GoToResultScene()  // 결과창 출력
    {
        SceneManager.LoadScene("04_Result");
    }   // GoToResultScene()

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

    public static bool isBS = false;    // 효과 관련
    public static void BlueScreenOn()   // 화면 안에 있는 장애물 삭제
    {
        if(_bsCnt-->0 && !FadeEffect.isPlaying)
        {
            isBS = true;
            // RemoveObstacle();
        }
        else
        {
            _bsCnt = 0;
        }
    }   // BlueScreenOn()

    public static void RemoveObstacle()    // 화면 장애물 삭제
    {
        GameObject checkScreen_1 = GameObject.FindGameObjectWithTag("CheckScreen_1");   // 스크린 가장 왼쪽 탐색
        GameObject checkScreen_2 = GameObject.FindGameObjectWithTag("CheckScreen_2");   // 스크린 가장 오른쪽 탐색
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Obstacle");   // 생성된 장애물 탐색
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].transform.position.x > checkScreen_1.transform.position.x && objects[i].transform.position.x < checkScreen_2.transform.position.x)
            {
                // 스크린에서 보이는 장애물 삭제
                Destroy(objects[i]);
            }
        }
    }   // RemoveObstacle()

}   // Game Class
