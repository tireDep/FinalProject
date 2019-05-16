using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{

    /*
     페이드 인&아웃 애니메이션 스크립트
     - 페이드 인, 페이드 아웃 함수
     */

    private float fadeTime = 2f; //  fade효과 재생 시간

    private Image fadeImg;

    private float start;
    private float end;
    private float time;
    private bool isPlaying = false;

    void Start()
    {
        fadeImg = GetComponent<Image>();
        FadeInAnimation();
    }   // Start()

    private void Update()
    {
        if (Audio.audioClipLength - Audio.audioSource.time < 2)
        {
            FadeOutAnimation();
        }
    }

    public void FadeInAnimation()
    {
        if (isPlaying)
        {
            return;
        }
        StartCoroutine("PlayFadeIn");
    }

    public void FadeOutAnimation()
    {
        if (isPlaying)
        {
            return;
        }
        StartCoroutine("PlayFadeOut");
    }

    IEnumerator PlayFadeIn()
    {
        isPlaying = true;
        start = 1f; //0.5f;
        end = 0f;

        Color color = fadeImg.color;
        time = 0f;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a > 0f)
        {
            time += Time.deltaTime / fadeTime;  // 2초 동안 재생됨
            color.a = Mathf.Lerp(start, end, time); // 알파 값 계산
            fadeImg.color = color;

            yield return null;
        }

        isPlaying = false;
    }

    IEnumerator PlayFadeOut()
    {
        start = 0f;
        end = 1f;
        isPlaying = true;

        Color color = fadeImg.color;
        time = 0f;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a < 1f)
        {
            time += Time.deltaTime / fadeTime;
            color.a = Mathf.Lerp(start, end, time);
            fadeImg.color = color;

            Game.RemoveObstacle();

            yield return null;
        }

        isPlaying = false;
    }
}
