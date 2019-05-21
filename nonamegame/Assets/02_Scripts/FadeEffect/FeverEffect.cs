using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeverEffect : FadeEffect
{
    private Image feverImg;
    void Start()
    {
        feverImg = GetComponent<Image>();
        feverImg.enabled = false;
    }

    private float alphaValue = 0.5f;
    void Update()
    {
        if (RangeOutDestroy.isDestroy)
        {
            feverImg.enabled = true;
            FadeInAnimation(feverImg, alphaValue, 2f);
            RangeOutDestroy.isDestroy = false;
        }
    }

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
            if (Player.isNoHit) // 진행되는 중 부딪힐 경우 취소됨
            {
                feverImg.enabled = false;
                isPlaying = false;
                StopCoroutine(corutine);
            }

            time += Time.deltaTime / fadeTime;  // 2초 동안 재생됨
            color.a = Mathf.Lerp(start, end, time); // 알파 값 계산
            fadeImg.color = color;

            Game.playerScore += 2.5f;

            yield return null;

        }
        isPlaying = false;
    }   // override IEnumerator PlayFadeIn()
}
