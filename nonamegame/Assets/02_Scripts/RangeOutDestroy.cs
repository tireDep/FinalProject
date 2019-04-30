using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeOutDestroy : MonoBehaviour
{
    /*
     오브젝트 삭제 스크립트
     - 오브젝트 삭제 함수
     */
    private void FixedUpdate()
    {
        ObjectDestroy();
    }

    void ObjectDestroy() // 물체가 화면밖에 있는 경우 삭제
    {
        Vector3 objectScreenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (objectScreenPos.x < - Screen.width / 2)  
        {
            Destroy(gameObject,10.0f);
        }

       /* Vector3 view = Camera.main.WorldToScreenPoint(transform.position);  // 월드 좌표 -> 스크린 좌표 변경
        if (view.x < Camera.main.transform.position.x)
        {
            Destroy(gameObject, 1.0f);
            Debug.Log(view.x + "//" + Camera.main.transform.position.x);
        }*/
    }   // ObjectDestroy()

}   // RangeOutDestroy Class
