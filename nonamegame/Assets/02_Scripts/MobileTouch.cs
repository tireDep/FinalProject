using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileTouch : MonoBehaviour
{
    void Update()
    {
        if (!Game.isPause && EventSystem.current.IsPointerOverGameObject() == false)
        {
            float camWidth = Camera.main.pixelWidth / 2;
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x > camWidth)
                {
                    Player.CheckPlayerPos();
                }
                else
                {
                    Player.PlayerJump();
                }
            }
        }
    }

}
