using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mobile : MonoBehaviour
{
    void Update()
    {
        if(!Game.isPause && !EndEffect.isEndEffect)
        {
            InputMoveForMobile();
        }

    }   // Update()

    public void InputMoveForMobile()    // 플레이어 입력 이동ver. Mobile
    {
        float camWidth = Camera.main.pixelWidth / 3;
        float camHeight = (Camera.main.pixelHeight / 4) * 3;

        if (Input.touchCount == 1)
        {
            Touch inputTouch = Input.GetTouch(0);
  
            if (inputTouch.phase == TouchPhase.Began)
            {
                CheckTouchPos(inputTouch, camWidth, camHeight);
            }
        }
    }

    void CheckTouchPos(Touch inputTouch, float camWidth, float camHeight)
    {
        if (!Game.isBS)
        {
            if (inputTouch.position.x < camWidth && inputTouch.position.y < camHeight)
            {
                Player.PlayerJump();
            }
            else if (inputTouch.position.x < camWidth * 2 && inputTouch.position.y < camHeight)
            {
                Game.BlueScreenOn();
            }
            else if (inputTouch.position.x < camWidth * 3 && inputTouch.position.y < camHeight)
            {
                Player.CheckPlayerPos();
            }
        }
    }   //  // CheckTouchPos(Touch inputTouch, float camWidth, float camHeight)


}   // Mobile Class
