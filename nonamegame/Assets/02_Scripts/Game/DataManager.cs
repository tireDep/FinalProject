using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Scene change

public class DataManager : MonoBehaviour
{
    /*
     변수값 관련 설정 스크립트
     - 모든 스크립트 변수 초기화 값 저장
     */

    private static float musicBPM;   //  음원 BPM 설정, 변경될 수 있는 값!
    public static float moveSpeed; // 이동속도 변수   

    public static float jumpPower = 27.0f; // 점프 힘 변수 /*!수정예정! - 그냥 점프가 수정되야될거같기도 하고*/
    public static int gravityForce = 100; // 중력변수
    public static int setPos = 2; // 플레이어 위치
    public static bool isDead = false;    // 생사여부

    public static int bsCnt = 5;    // 화면지우기 카운트

    private void Awake()
    {
        /* 
         BPM 140, moveSpeed 15.0f
         => BPM 9.3, moveSpeed 1.0f
      
         MixMeister BPM Analyzer 이용 BPM 확인
         
         Under the rain. Background piano music - 108
         Coporate Technology And Science - 120
         기분좋은 오후(Happy Afternoon) - 123.5
         000 A Lively Dynamic - 140
        */
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            musicBPM = 108f;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            musicBPM = 120f;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            musicBPM = 123.5f;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            musicBPM = 140f;
        }
        SetMoveSpeed(musicBPM);
    }   // Awake()

    void SetMoveSpeed(float musicBPM)
    {
        moveSpeed = musicBPM / 9.3f;
    }

    public static void ResetValue()    // 재시작시 static 값 초기화
    {
        FadeEffect.isPlaying = false;
        StartEndEffect.isStartEndEffect = false;
        Game.isBS = false;
        Audio.isCheckPoint = false;
    }   // ResetValue()

}   // DataManager Class
