using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Scene change
using UnityEngine.UI;   // UI

public class Audio : MonoBehaviour
{
    public static AudioSource audioSource;    // 음원 설정
    public static Slider slider;  // 진행상태
    public AudioClip audioClip;    // 음원
    public Text songTitle;  // 노래 제목
    static public bool isAudioFin;    // 오디오 체크 변수

    public static bool isCheckPoint;    // 체크포인트 확인
    public static float checkPointTime; // 체크포인트 생성 시간
    private static float addTime; // 체크포인트 생성 시간 저장 변수

    public static float audioClipLength;    // 음악길이 변수

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        slider = GetComponent<Slider>();

        isAudioFin = false; // 음원 종료 여부

        checkPointTime = audioClip.length / 10;
        isCheckPoint = false;
        addTime = checkPointTime;
        // 체크포인트 설정

        slider.minValue = 0;
        slider.maxValue = audioClip.length;
        // 슬라이더 값 설정

        songTitle.text = audioClip.name;    // 곡 이름 설정

        audioSource.clip = audioClip;   // 곡 설정


        audioSource.Play(); // 음악 설정

        audioClipLength = audioClip.length; // 음악 길이 설정

    }   // Start()

    void Update()
    {
        slider.value = audioSource.time;    // 곡 진행에 따른 슬라이더 이동

        if((slider.value==audioClip.length) || (!audioSource.isPlaying && !Game.isPause))
        {
            isAudioFin = true;
        }

        CheckPlayTime();
    }   //   Update()

    bool isPassTime = false;    // 생성시간에 1번 생성 체크
    void CheckPlayTime()    // 진행상황에 따른 체크포인트 생성
    {
        if (!isPassTime&&(int)audioSource.time == (int)checkPointTime)
        {
            isCheckPoint = true;
            isPassTime = true;
            checkPointTime += addTime;
        }

        else // 1번 생성 체크
        {
            isPassTime = false;
            isCheckPoint = false;
        }
    }   //   CheckPlayTime()

    public void MovePosition()  // 슬라이더 이동시 곡도 이동
    {
        if(slider.value!=slider.maxValue)
        {
            audioSource.time = slider.value;
        }
    }   // MovePosition()

}   // Audio Class
