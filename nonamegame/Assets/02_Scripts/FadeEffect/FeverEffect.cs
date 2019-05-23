using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeverEffect : FadeEffect
{
    private Image feverImg;

    public Image fastStatusImg;
    public Image slowStatusImg;

    public static bool isFever;
    void Start()
    {
        feverImg = GetComponent<Image>();
        feverImg.enabled = false;
        fastStatusImg.enabled = false;
        slowStatusImg.enabled = false;

        isFever = false;
    }   // Start()

    private float alphaValue = 1.0f;
    float randomValue;
    void Update()
    {
        if (RangeOutDestroy.isDestroy)
        {
            feverImg.enabled = true;
            FadeInAnimation(feverImg, alphaValue, 5f);
            RangeOutDestroy.isDestroy = false;
        }
    }   // Update()

    public override IEnumerator PlayFadeIn(Image fadeImg, float inputStart, float inputfadeTime)    // 페이드 인 효과
    {
        CheckStatus();
        Player.playerMoveSpeed = Player.playerMoveSpeed * randomValue;
        Game.camMoveSpeed = Game.camMoveSpeed * randomValue;
        Audio.audioSource.pitch = randomValue;
        // 랜덤으로 변속 설정

        isFever = true;
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
                // feverImg.enabled = false;
                color.a = 0;
                feverImg.color = color;
                BreakEffect_Fever();
                StopCoroutine(corutine);
            }
            else
            {
                time += Time.deltaTime / fadeTime;
                color.a = Mathf.Lerp(start, end, time); // 알파 값 계산
                fadeImg.color = color;

                Game.playerScore += 2.5f;
            }
            yield return null;
        }
        BreakEffect_Fever();
    }   // override IEnumerator PlayFadeIn()

    void CheckStatus()  // 랜덤으로 변속 설정
    {
        int ranNum = Random.Range(0, 2);   // 0에서 1까지 랜덤 수
        if (ranNum == 0)
        {
            randomValue = 0.75f;
            slowStatusImg.enabled = true;
            fastStatusImg.enabled = false;
        }
        else if (ranNum == 1)
        {
            randomValue = 1.25f;
            fastStatusImg.enabled = true;
            slowStatusImg.enabled = false;
        }
    }   // CheckStatus()

    void BreakEffect_Fever()   // 값 초기화
    {
        isPlaying = false;
        Player.playerMoveSpeed = DataManager.moveSpeed;
        Game.camMoveSpeed = DataManager.moveSpeed;
        Audio.audioSource.pitch = 1.0f;

        fastStatusImg.enabled = false;
        slowStatusImg.enabled = false;

        isFever = false;
    }   // BreakEffect_Fever()

}   // FeverEffect Class
