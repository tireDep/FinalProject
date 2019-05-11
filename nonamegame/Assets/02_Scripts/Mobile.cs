using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobile : MonoBehaviour
{
    /*
     모바일 입력 스크립트
     */


    /*private int touchSensitivityHorizontal = 0;
    private int touchSensitivityVertical = 0;
    // 화면 가로지르는 거

    Vector2 previsousUnitPosition = Vector2.zero;
    Vector2 direction = Vector2.zero;

    bool moved = false;
    */

    void MobileInput()
    {
        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase==TouchPhase.Began)   
            {

            }
            else if(touch.phase==TouchPhase.Moved)
            {

            }
            else if(touch.phase==TouchPhase.Ended)
            {

            }

        }
    }   // MobileInput()

}   // Mobile Class
