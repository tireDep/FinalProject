using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobile : MonoBehaviour
{
    private static Mobile instance;

    private void Awake()    // checkPoint 관련
{
    if(instance==null)
    {
        instance = this;
        DontDestroyOnLoad(instance);    // 삭제방지
    }
    else
    {
        Destroy(gameObject);
    }
}   // Awake()

    void Start()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        // 모바일 화면 가로 고정
    }   // Start()

}   // Mobile Class
