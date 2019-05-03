using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Scene change
using UnityEngine.UI;   // UI

public class Audio : MonoBehaviour
{
    /*
     음악 관련 스크립트
     - 게임 음악 설정 및 진행바 이동
     - 게임 UI 설정(슬라이더, 곡 정보)
    */

    public static AudioSource audioSource;    // 음원 설정
    public static Slider slider;  // 진행상태
    public AudioClip audioClip;    // 음원
    public Text songTitle;  // 노래 제목
    static public bool isAudioFin;    // 오디오 체크 변수

    public static bool isCheckPoint;    // 체크포인트 확인
    public static float checkPointTime; // 체크포인트 생성 시간
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        slider = GetComponent<Slider>();

        isAudioFin = false; // 음원 종료 여부

        checkPointTime = audioClip.length / 10;
        isCheckPoint = false;
        // 체크포인트 설정

        slider.minValue = 0;
        slider.maxValue = audioClip.length;
        // 슬라이더 값 설정

        songTitle.text = audioClip.name;    // 곡 이름 설정

        audioSource.clip = audioClip;   // 곡 설정
        /* !수정예정! - fade_in fade_out 추가? */

        audioSource.Play(); // 음악 설정

        // Invoke("FinishedAudio", audioClip.length);  // 음악이 끝나면 실행
    }   // Start()

    void Update()
    {
        slider.value = audioSource.time;    // 곡 진행에 따른 슬라이더 이동

        if((slider.value==audioClip.length) || (!audioSource.isPlaying && !Game.isPause))
        {
            FinishedAudio();
        }

        CheckPlayTime();
    }   //   Update()

    float nowTime = 0;  // 체크포인트 확인 시간
    bool isPassTime = false;    // 생성시간에 1번 생성 체크
    void CheckPlayTime()    // 진행상황에 따른 체크포인트 생성
    {
        nowTime += Time.deltaTime;
        //Debug.Log(nowTime + "//" + checkPointTime);

        if ((int)nowTime == (int)checkPointTime && !isPassTime)
        {
            isCheckPoint = true;
            isPassTime = true;
            nowTime = 0;
        }

        if (nowTime > 1)    // 1번 생성 체크
        {
            isPassTime = false;
        }
    }   //   CheckPlayTime()


    void FinishedAudio() // 노래 끝날 경우 게임 종료
    {
        //Debug.Log("Audio Fin");
        isAudioFin = true;  
    }   // FinishedAudio()

    /* 후에 삭제! */
    public void MovePosition()  // 슬라이더 이동시 곡도 이동
    {
        audioSource.time = slider.value;
    }   // MovePosition()

}   // Audio Class
