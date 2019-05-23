using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartEffect : FadeEffect
{
    private Image startImg;

    private float alphaValue = 0.5f;
    private void Awake()
    {
        isPlaying = false;
        startImg = GetComponent<Image>();
        FadeInAnimation(startImg, alphaValue, 1.0f);
    }   // Awake()

}   // StartEffect Class
