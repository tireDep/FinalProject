using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BSEffect : FadeEffect  // FadeEffect 상속
{
    /*
     블루스크린 효과 스크립트
     - BS관련 키 입력시 FadeIn애니메이션 실행&화면 장애물 삭제
     */

    private Image BSImg;

    private void Awake()
    {
        BSImg = GetComponent<Image>();
        BSImg.enabled = false;
    }   // Awake()

    private float alphaValue = 0.5f;
    private void Update()
    {
        if (Game.isBS)
        {
            BSImg.enabled = true;
            FadeInAnimation(BSImg, alphaValue, 0.5f);
            Game.isBS = false;
        }
        //BSImg.enabled = false;
    }   // Update()

    public override IEnumerator PlayFadeIn(Image fadeImg, float inputStart, float inputfadeTime)    // 페이드 인 효과
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
            fadeImg.color = color;

            Game.RemoveObstacle();  // 장애물 삭제 실행
            
            yield return null;
        }

        isPlaying = false;
    }   // override IEnumerator PlayFadeIn()

}   // BSEffect Class
