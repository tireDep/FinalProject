﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    /*
     지형 및 장애물 생성 관련 스크립트
     - 바닥 생성 함수
     - 장애물 생성 함수
     - 랜덤위치 설정 함수
     */

    public Transform mapBlock;  // 프리팹
    private Transform newMapBlock;  // 맵 생성
    private int makeBlock = 0;  // 맵 개수 변수
    int testcnt = 0; // !수정예정!

    public void CreateMap()    // 기본 1자 바닥 생성
    {
        newMapBlock = Instantiate(mapBlock, new Vector3(makeBlock++, 1, 0), Quaternion.identity);
        testcnt++;
        if(testcnt%10==0)
        {
            CreateObstacle(makeBlock);
        }
    }   // CreateMap()

    public Transform boxObstacle;
    public Transform snailObstacle;
    public Transform longObstacle;
    // 장애물 종류
    Transform newObsBlock_up;
    Transform newObsBlock_down;
    // 장애물 생성 위치
    Transform tempBlock;    // 생성할 장애물 설정
    float setY = 0; // 장애물 위치  설정
    void CreateObstacle(int makeBlock)    // 장애물 생성
    {
        RandomObstacle(1);
        newObsBlock_up = Instantiate(tempBlock, new Vector3(makeBlock+5, setY, 0), Quaternion.identity);
        RandomObstacle(-1);
        newObsBlock_down = Instantiate(tempBlock, new Vector3(makeBlock+10, setY, 0), Quaternion.Euler(180,0,0));
    }   // CreateObstacle()

    void RandomObstacle(int pos)    // 랜덤 장애물 생성
    {
        // int pos : 장애물 생성 위치
        int randomObstacle = Random.Range(1, 4);

        switch (randomObstacle)
        {
            case 1:
                tempBlock = boxObstacle;
                CheckObstacle(pos, 1);
                break;

            case 2:
                tempBlock = snailObstacle;
                CheckObstacle(pos, 2);
                break;

            case 3:
                tempBlock = longObstacle;
                CheckObstacle(pos, 3);
                break;

            default:
                tempBlock = boxObstacle;
                CheckObstacle(pos, 1);
                break;
        }
    }   // RandomObstacle(Transform tempBlock, int pos, float setY)

    void CheckObstacle(int pos, int checkNum)   // 장애물 위치 설정
    {
        if(pos ==1)
        {
            if(checkNum==1)
            {
                setY = 2.01f;
            }
            else if(checkNum==2)
            {
                setY = 1.81f;
            }
            else if(checkNum==3)
            {
                setY = 2.96f;
            }
        }
        else
        {
            if(checkNum==1)
            {
                setY = -0.0f;
            }
            else if (checkNum == 2)
            {
                setY = 0.19f;
            }
            else if (checkNum == 3)
            {
                setY = -0.96f;
            }
        }
    }   // checkObstacle(int pos, int checkNum)

}   // Map Class
