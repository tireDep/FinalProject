using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Scene change

public class BackGroundMusic : MonoBehaviour
{
    /*
     배경음악 관련 스크립트
     - 시작화면, 스테이지 화면에서의 배경음악
     */

    public AudioClip backGroundMusic;   // 배경음악 음원
    public static AudioSource audioSource;  // 배경음악 설정

   private static BackGroundMusic instance;

    private void Start()
    {
        /*if (instance == null)
        {
           instance = this;
           //DontDestroyOnLoad(gameObject);    // 씬 넘어가도 파괴 x
           audioSource = GetComponent<AudioSource>();

          audioSource.clip = backGroundMusic;
          audioSource.Play();
        }*/
        DontDestroyOnLoad(gameObject);    // 씬 넘어가도 파괴 x
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = backGroundMusic;
        audioSource.Play();

    }   // Start()

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex > 1)
        {
            Destroy(gameObject);   // 시작화면, 스테이지가 아닐경우 삭제
        }
    }   // Update()

}   // BackGroundMusic Class
