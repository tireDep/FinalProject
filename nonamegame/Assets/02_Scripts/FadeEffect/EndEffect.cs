using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndEffect : FadeEffect
{
    private Image endImg;
    public Canvas canvasUI;

    public static bool isEndEffect = false;
    private void Awake()
    {
        endImg = GetComponent<Image>();
        endImg.enabled = false;
    }   // Awake()

    private void Update()
    {
        if (Audio.audioClipLength - Audio.audioSource.time < 2)
        {
            endImg.enabled = true;
            canvasUI.enabled = false;
            isEndEffect = true;

            Camera.main.transform.Translate(-DataManager.moveSpeed * 2 * Time.deltaTime, 0f, 0f);
            // 플레이어 캐릭터가 앞으로 전진하는 것처럼 출력됨

            FadeOutAnimation(endImg);
        }
    }   // Update()

}   // EndEffect Class
