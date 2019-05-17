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

    public static float fadeTime; //  fade효과 재생 시간

    private Image fadeImg;  // 페이드 애니메이션 이미지

    private float start;    // Mathf.Lerp 시작점
    private static float end;      // Mathf.Lerp 종료점
    private static float time; // Mathf.Lerp 거리비율
    public static bool isPlaying = false; // 실행 유무 확인

    public void FadeInAnimation(Image fadeImg, float inputStart, bool isBS, float inputfadeTime)
    {
        if (isPlaying)  // 한 번만 실행
        {
            return;
        }
        StartCoroutine(PlayFadeIn(fadeImg, inputStart, isBS, inputfadeTime));
    }   // FadeInAnimation()

    public void FadeOutAnimation(Image fadeImg)
    {
        if (isPlaying)
        {
            return;
        }
        StartCoroutine("PlayFadeOut", fadeImg);
    }   // FadeOutAnimation()

    IEnumerator PlayFadeIn(Image fadeImg, float inputStart, bool isBS, float inputfadeTime)    // 페이드 인 효과
    {
        isPlaying = true;
        start = inputStart;
        end = 0f;
        fadeTime = inputfadeTime;

        Color color = fadeImg.color;
        time = 0f;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a > 0f)
        {
            time += Time.deltaTime / fadeTime;  // 2초 동안 재생됨
            color.a = Mathf.Lerp(start, end, time); // 알파 값 계산
            /*
             Mathf.Lerp(float 시작점, float 종료점, flaot 거리비율)
             - 시작점과 종료점 사이의 거리비율에 해당 하는 값 반환
             - 거리비율은 0 ~ 1 사이 값 고정, % 의미
             */
            fadeImg.color = color;

            if(isBS)
            {
                Game.RemoveObstacle();
            }
            yield return null;
        }

        isPlaying = false;
    }   // PlayFadeIn()

    IEnumerator PlayFadeOut(Image fadeImg)   // 페이드 아웃 효과
    {
        start = 0f;
        end = 1f;
        isPlaying = true;
        fadeTime = 2f;

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
    }   // PlayFadeOut()

}   // FadeEffect Class
