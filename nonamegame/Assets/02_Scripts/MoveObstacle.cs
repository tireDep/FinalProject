using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    /*
     움직이는 장애물 관련 스크립트
     - 이동
     - 후에 상하이동도 추가될듯
    */

    void Update()
    {
        Move();
    }   // Update()

    void Move()
    {
        transform.Translate(-2f * Time.deltaTime, 0f, 0f);
    }   // Move()

}   // MoveObstacle Class
