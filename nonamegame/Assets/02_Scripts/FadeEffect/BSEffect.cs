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

    public Image BSImg;
    public static bool _isPlaying;

    private void Awake()
    {
        BSImg = GetComponent<Image>();
        BSImg.enabled = false;

        _isPlaying = false;
    }   // Awake()

    private float alphaValue = 0.5f;
    private void Update()
    {
        if (Game.isBS)
        {
            BSImg.enabled = true;
            FadeInAnimation_BS(BSImg, alphaValue, 0.5f);
            Game.isBS = false;
        }
    }   // Update()

    public void FadeInAnimation_BS(Image fadeImg, float inputStart, float inputfadeTime)    // 페이드 인 효과
    {
        // 변수 : 적용할 이미지, 시작점, BS 실행 유무, 진행시간
        if (_isPlaying)  // 한 번만 실행
        {
            return;
        }
        corutine = PlayFadeIn_BS(fadeImg, inputStart, inputfadeTime);
        StartCoroutine(corutine);
    }   // FadeInAnimation()

    public IEnumerator PlayFadeIn_BS(Image fadeImg, float inputStart, float inputfadeTime)    // 페이드 인 효과
    {
        _isPlaying = true;
        start = inputStart;
        end = 0f;
        fadeTime = inputfadeTime;

        Color color = fadeImg.color;
        time = 0f;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a > 0f)
        {
            if(Player.isPlayerCheckPoint)// FeverEffect.isFever) // 피버 때 실행x
            {
                // BSImg.enabled = false; // 이렇게 하면 장애물 계속 삭제됨..
<<<<<<< HEAD
                BreakEffect_BS(color);
            }
            else if(EndEffect.isEndEffect)
            {
                BreakEffect_BS(color);
=======
                color.a = 0;
                BSImg.color = color;
                _isPlaying = false;
                StopCoroutine(corutine);
>>>>>>> ec2943ecac8f414fb3bd68840ad40cb73f440250
            }
            else
            {
                time += Time.deltaTime / fadeTime;  // 2초 동안 재생됨
                color.a = Mathf.Lerp(start, end, time); // 알파 값 계산
                fadeImg.color = color;
                Game.RemoveObstacle();  // 장애물 삭제 실행
            }
            yield return null;
        }

        _isPlaying = false;
    }   // override IEnumerator PlayFadeIn()

    void BreakEffect_BS(Color color)
    {
        color.a = 0;
        BSImg.color = color;
        _isPlaying = false;
        StopCoroutine(corutine);
    }   // BreakEffect_BS()

}   // BSEffect Class
