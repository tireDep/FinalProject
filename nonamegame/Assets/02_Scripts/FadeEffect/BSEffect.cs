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
            FadeInAnimation(BSImg, alphaValue, Game.isBS, 0.5f);
            Game.isBS = false;
        }
        //BSImg.enabled = false;
    }   // Update()

}   // BSEffect Class
