using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartEndEffect : FadeEffect    // FadeEffect 상속
{
    /*
     게임 시작&끝 이펙트 효과 스크립트
     - 게임 시작과 끝에서 이펙트 효과 출력
     */

    private Image StartEndImg;
    public Canvas canvasUI;

    private float alphaValue = 1.0f;
    private void Awake()
    {
        StartEndImg = GetComponent<Image>();
        FadeInAnimation(StartEndImg, alphaValue, Game.isBS, 2.0f);
    }   // Awake()

    private void Update()
    {
        if (Audio.audioClipLength - Audio.audioSource.time < 2)
        {
            canvasUI.enabled = false;
            FadeOutAnimation(StartEndImg);
        }
    }   // Update()

}   // StartEndEffect Class
