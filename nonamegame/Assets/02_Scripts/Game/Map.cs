using System.Collections;
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

    int testObstacleCnt = 0; // !수정예정! 임시 장애물 생성
    public static bool isObsCreate=false;
    private void Update()
    {
        if(!Game.isPause)
        {
            CheckPlayTime();    // 지형 생성 관련

            testObstacleCnt++;
            if (testObstacleCnt % 10 == 0)
            {
                isObsCreate = true;
            }   // 장애물 임시 생성

        }

        if (Audio.isCheckPoint)
        {
            GetComponent<Map>().CreateCheckPoint();
        }   // 체크포인트 생성 여부 판별

    }   //  Update()

    float playTime = 0.0f;    // 경과시간
    private void CheckPlayTime()    // 플레이시간 몇 초 지나갔는지 확인
    {
        playTime += Time.deltaTime;
        if (playTime <= Audio.audioClipLength) // 일시정지x && 음원길이보다 적은 시간일경우 맵 생성
        {
            CreateMap(); 
        }
    }   // CheckPlayTime() 

    public Transform mapBlock;  // 프리팹
    public static int makeBlock = 15;  // 맵 개수 변수
    public void CreateMap()    // 기본 1자 바닥 생성
    {
        Transform newMapBlock = Instantiate(mapBlock, new Vector3(++makeBlock, 1, 0), Quaternion.identity);
        newMapBlock.SetParent(transform);
    }   // CreateMap()

    public Transform checkPoint;
    Transform makecheckPoint;    // 위방향
    public void CreateCheckPoint()  // 체크포인트 생성
    {
        float _playerPosX = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        makecheckPoint = Instantiate(checkPoint, new Vector3(_playerPosX + 10, 2.01f, 0), Quaternion.identity);

        float checkPointPos = makecheckPoint.transform.position.x;
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Obstacle");
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].transform.position.x > checkPointPos - 3 && objects[i].transform.position.x < checkPointPos + 3)
            {
                Destroy(objects[i]);
            }
        }
        // 체크포인트 근처 장애물 삭제

    }   // CreateCheckPoint()


}   // Map Class
