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
    private void Update()
    {
        if(!Game.isPause)
        {
            CheckPlayTime();    // 지형 생성 관련

            testObstacleCnt++;
            if (testObstacleCnt % 10 == 0)
            {
                CreateObstacle(makeBlock);
            }   // 장애물 임시 생성

        }

        if (Audio.isCheckPoint)
        {
            GetComponent<Map>().CreateCheckPoint();
            Audio.isCheckPoint = false;
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
        else
        {
            Debug.Log("check!!");
        }
        //Debug.Log(playTime + "//" + Audio.audioClipLength);
    }   // CheckPlayTime() 

    public Transform mapBlock;  // 프리팹
    private int makeBlock = 15;  // 맵 개수 변수
    public void CreateMap()    // 기본 1자 바닥 생성
    {
        Transform newMapBlock = Instantiate(mapBlock, new Vector3(++makeBlock, 1, 0), Quaternion.identity);
        newMapBlock.SetParent(transform);
    }   // CreateMap()

    /*public int GetBlockCount()
    {
        return transform.childCount;
    }*/

    public Transform boxObstacle;
    public Transform snailObstacle;
    public Transform longObstacle;
    public Transform flyerObstacle;
    public Transform fishObstacle;
    public Transform slimeObstacle;
    // 장애물 종류

    Transform newObsBlock_up;
    Transform newObsBlock_down;
    // 장애물 생성 위치

    Transform tempBlock;    // 생성할 장애물 설정
    float setY = 0; // 장애물 위치  설정
    int setEuler = 0;   // 장애물 뒤집기 유무 설정
    void CreateObstacle(int makeBlock)    // 장애물 생성
    {
        RandomObstacle(1);
        newObsBlock_up = Instantiate(tempBlock, new Vector3(makeBlock+5, setY, 0), Quaternion.identity);
        RandomObstacle(-1);
        newObsBlock_down = Instantiate(tempBlock, new Vector3(makeBlock+10, setY, 0), Quaternion.Euler(setEuler*180,0,0));
    }   // CreateObstacle()

    void RandomObstacle(int pos)    // 랜덤 장애물 생성
    {
        // int pos : 장애물 생성 위치
        int randomObstacle = Random.Range(1, 6);

        switch (randomObstacle)
        {
            case 1:
                tempBlock = boxObstacle;
                CheckObstacle(pos, 1);
                break;

            case 2:
                tempBlock = longObstacle;
                CheckObstacle(pos, 2);
                break;

            case 3:
                if(pos>0)
                {
                    tempBlock = flyerObstacle;
                }
                else
                {
                    tempBlock = fishObstacle;
                }
                CheckObstacle(pos, 3);
                break;

            case 4:
                if (pos > 0)
                {
                    tempBlock = snailObstacle;
                }
                else
                {
                    tempBlock = slimeObstacle;
                }
                CheckObstacle(pos, 4);
                break;

            default:
                tempBlock = boxObstacle;
                CheckObstacle(pos, 1);
                break;
        }
    }   // RandomObstacle(Transform tempBlock, int pos, float setY)

    void CheckObstacle(int pos, int checkNum)   // 장애물 위치 설정
    {
        if (pos ==1)
        {
            SetUpObsPos(checkNum);
        }
        else
        {
            SetDownObsPos(checkNum);
        }
    }   // checkObstacle(int pos, int checkNum)

    // !수정예정! - 스크립트화 or 리스트?
    void SetUpObsPos(int checkNum)  // 윗 장애물 위치 설정
    {
        if (checkNum == 1)
        {
            setY = 2.01f;
        }
        else if (checkNum == 2)
        {
            setY = 2.96f;
        }
        else if (checkNum == 3)
        {
            float randomMove = Random.Range(3.0f, 5.5f);
            setY = randomMove;
        }
        else if (checkNum == 4)
        {
            setY = 1.81f;
        }
    }   // SetUpObsPos(int checkNum)

    void SetDownObsPos(int checkNum)    // 아랫 장애물 위치 설정
    {
        if (checkNum == 1)
        {
            setEuler = 1;
            setY = -0.0f;
        }
        else if (checkNum == 2)
        {
            setEuler = 1;
            setY = -0.96f;
        }
        else if (checkNum == 3)
        {
            float randomMove = Random.Range(-1.0f, -2.5f);
            setEuler = 0;
            setY = randomMove;
        }
        else if (checkNum == 4)
        {
            setEuler = 1;
            setY = 0.24f;
        }
    }   // SetDownObsPos(int checkNum)


    public Transform checkPoint;
    Transform checkPoint_up;    // 위방향
    Transform checkPoint_down;  // 아래방향
    public void CreateCheckPoint()  // 체크포인트 생성
    {
        //Debug.Log("checkPoint");
        checkPoint_up = Instantiate(checkPoint, new Vector3(makeBlock - 5, 2.01f, 0), Quaternion.identity);
        checkPoint_down = Instantiate(checkPoint, new Vector3(makeBlock - 5, -0.0f, 0), Quaternion.Euler(180, 0, 0));
    }   // CreateCheckPoint()

}   // Map Class
