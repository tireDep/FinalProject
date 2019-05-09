﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    /*
     변수값 관련 설정 스크립트
     - 모든 스크립트 변수 초기화 값 저장
     */

    private static float musicBPM = 110.34f;   //  음원 BPM 설정, 변경될 수 있는 값!
    public static float moveSpeed = musicBPM / 9.3f; // 이동속도 변수
    /*
    * BPM 140, moveSpeed 15.0f
    *  => BPM 9.3, moveSpeed 1.0f
    *  
    *  MixMeister BPM Analyzer 이용 BPM 확인
    */
    // !수정예정! - BPM 스크립트화


    public static float jumpPower = 27.0f; // 점프 힘 변수 /*!수정예정! - 그냥 점프가 수정되야될거같기도 하고*/
    public static int gravityForce = 100; // 중력변수
    public static int setPos = 2; // 플레이어 위치
    public static bool isDead = false;    // 생사여부

    public static int bsCnt = 5;    // 화면지우기 카운트

}   // DataManager Class
