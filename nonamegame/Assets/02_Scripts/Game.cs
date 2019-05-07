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

    public static int maxScore = 1000000;  // 최고점수
    public static int playerScore;  // 플레이어 점수
    public Text playerScorText; // 점수 UI

    public UnityEngine.UI.Image fadePanel;   // fade 효과 관련

    //private static Game instance;   // of type Game
    public Vector3 lastCheckPointPos;   // 플레이어 위치
    public Vector3 lastCheckCamera;  // 카메라 위치
    public float lastCheckAudio;   //  음악진행사항
    // 체크포인트 관련

    /*private void Awake()    // checkPoint 관련
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(instance);    // 삭제방지
        }
        else
        {
            Destroy(gameObject);
        }
    }   // Awake()*/

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

        fadePanel.enabled = false;
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

    float fadeTime = 0;
    float time = 0; 
    // fade 시간 관련 변수들
    void GoToResultScene()  // 페이드 효과 및 화면 전환
    {
        fadePanel.enabled = true;
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Obstacle");   // 생성된 장애물 탐색
        for (int i = 0; i < objects.Length; i++)
        {
                Destroy(objects[i]);
        }

        while (fadeTime<=255)
        {
            time += Time.deltaTime;
            if (time >= 0.1f)
            {
                fadeTime += 50;
                fadePanel.color = new Color(0, 0, 0, fadeTime);
                //iTween.FadeFrom(fadePanel.gameObject, 0.0f, 10f);   // 투명화
                //iTween.FadeTo(fadePanel.gameObject, 0.0f, 10f);   //   불투명화
                time = 0;
            }
        }
        SceneManager.LoadScene("GameResult");
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

    static public void BlueScreenOn()   // 화면 안에 있는 장애물 삭제
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
    }   // BlueScreenOn()

}   // Game Class
