using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeOutDestroy : MonoBehaviour
{
    /*
     오브젝트 삭제 스크립트
     - 오브젝트 삭제 함수
     */

    void Update()
    {
        ObjectDestroy();
    }   // Update()

    void ObjectDestroy() // 물체가 화면밖에 있는 경우 삭제
    {
        Vector3 view = Camera.main.WorldToScreenPoint(transform.position);  // 월드 좌표 -> 스크린 좌표 변경
        if (view.x < Camera.main.transform.position.x)
        {
            Destroy(gameObject, 1.0f);
            // 바로 삭제될 경우 너무 빠르게 삭제 되어서 화면 것도 같이 삭제됨
        }
    }   // ObjectDestroy()

}   // RangeOutDestroy Class
