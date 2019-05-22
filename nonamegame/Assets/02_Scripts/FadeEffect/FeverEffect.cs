using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeverEffect : FadeEffect
{
    private Image feverImg;

    public Image fastStatusImg;
    public Image slowStatusImg;

    void Start()
    {
        feverImg = GetComponent<Image>();
        feverImg.enabled = false;
        fastStatusImg.enabled = false;
        slowStatusImg.enabled = false;
    }   // Start()

    private float alphaValue = 1.0f;
    float randomValue;
    void Update()
    {
        if (RangeOutDestroy.isDestroy)
        {
            Debug.Log(BSEffect._isPlaying + " // " + isPlaying);
            feverImg.enabled = true;
            FadeInAnimation(feverImg, alphaValue, 5f);
            RangeOutDestroy.isDestroy = false;
        }
    }   // Update()

    void CheckStatus()
    {
        int ranNum = Random.Range(0, 2);   // 0에서 1까지 랜덤 수
        if (ranNum == 0)
        {
            randomValue = 0.75f;
            slowStatusImg.enabled = true;
            fastStatusImg.enabled = false;
        }
        else if(ranNum == 1)
        {
            randomValue = 1.25f;
            fastStatusImg.enabled = true;
            slowStatusImg.enabled = false;
        }
    }   // CheckStatus()

    public override IEnumerator PlayFadeIn(Image fadeImg, float inputStart, float inputfadeTime)    // 페이드 인 효과
    {
        // 변속 효과 임시적용
        CheckStatus();

        Player.playerMoveSpeed = Player.playerMoveSpeed * randomValue;
        Game.camMoveSpeed = Game.camMoveSpeed * randomValue;
        Audio.audioSource.pitch = randomValue;

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
                ResetValue();
                StopCoroutine(corutine);
            }

            time += Time.deltaTime / fadeTime;  // 2초 동안 재생됨
            // Debug.Log(time);
            color.a = Mathf.Lerp(start, end, time); // 알파 값 계산
            fadeImg.color = color;

            Game.playerScore += 2.5f;

            yield return null;

        }
        ResetValue();
    }   // override IEnumerator PlayFadeIn()

    void ResetValue()
    {
        isPlaying = false;
        Player.playerMoveSpeed = DataManager.moveSpeed;
        Game.camMoveSpeed = DataManager.moveSpeed;
        Audio.audioSource.pitch = 1.0f;

        fastStatusImg.enabled = false;
        slowStatusImg.enabled = false;
    }   // ResetValue()

}   // FeverEffect Class
