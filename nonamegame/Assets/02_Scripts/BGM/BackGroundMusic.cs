using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Scene change

public class BackGroundMusic : MonoBehaviour
{
    public AudioClip backGroundMusic;   // 배경음악 음원
    public static AudioSource audioSource;  // 배경음악 설정

    private static BackGroundMusic instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);    // 씬 넘어가도 파괴 x

            audioSource = GetComponent<AudioSource>();
            audioSource.clip = backGroundMusic;
            audioSource.Play();
        }
        else
        {
            Destroy(this.gameObject);   // 이미 존재할 경우 파괴(중복 재생x)
        }
    }   // Start()

    private void Update()
    {
        CheckBGM();

    }   // Update()

    void CheckBGM()
    {
        if (SceneManager.GetActiveScene().buildIndex > 1)   // 시작화면, 스테이지 x => 일시정지
        {
            audioSource.Stop();
        }

        else
        {
            // 시작화면, 스테이지 x => 일시정지
            if (!audioSource.isPlaying) // 중복 재생 방지
            {
                audioSource.Play();
            }
        }
    }   // CheckBGM()

}   // BackGroundMusic Class
