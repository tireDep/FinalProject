﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeOutDestroy : MonoBehaviour
{
    /*
     오브젝트 삭제 스크립트
     - 오브젝트 삭제 함수
     */

    private void Update()
    {
        ObjectDestroy();
    }   // Update()

    public static bool isDestroy = false;
    void ObjectDestroy() // 물체가 화면밖에 있는 경우 삭제
    {
        if ((this.transform.position.x < GameObject.FindGameObjectWithTag("Player").transform.position.x - 10) && Player.isPlayerCheckPoint)
        {
            // 해당 오브젝트 x축 < 플레이어 x축 - 10 && 체크포인트 지나감(삭제 가능여부)
            // -10은 재시작시 길 끊어지지 않게 보이기 위해 설정
            Destroy(gameObject);
            Game._bsCnt = DataManager.bsCnt;    //   화면 삭제 변수 초기화 -> 여러번 실행 방지 위해 이동
            isDestroy = true;
        }
    }   // ObjectDestroy() 

}   // RangeOutDestroy Class
