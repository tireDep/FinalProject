using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Transform boxObstacle;
    public Transform flyerObstacle;
    public Transform fishObstacle;
    // 장애물 종류
    float passTime = 0;

    int obstaclePos;
    private void Update()
    {
        obstaclePos = Map.makeBlock;
        if (Map.isObsCreate)
        {
            CreateObstacle(obstaclePos);
            Map.isObsCreate = false;
        }

        passTime += Time.deltaTime;
        if(passTime >= 0.75f) /*Player.isHiting)//*/
        {
            passTime = 0;
            CreateMoveObstacle();
        }
    }

    Transform newObsBlock_up;
    Transform newObsBlock_down;
    // 장애물 생성 위치

    Transform tempBlock;    // 생성할 장애물 설정
    float setY = 0; // 장애물 위치  설정
    int setEuler = 0;   // 장애물 뒤집기 유무 설정
    
    int ranNumArrUp;
    int ranNumArrDown;
    void CreateObstacle(int makeBlock)    // 장애물 생성
    {
        ranNumArrUp = Random.Range(-3, 0);
        RandomObstacle(1);
        newObsBlock_up = Instantiate(tempBlock, new Vector3(obstaclePos  + ranNumArrUp, setY, 0), Quaternion.identity);
        newObsBlock_up.SetParent(transform);

        ranNumArrDown = Random.Range(1, 3);
        RandomObstacle(-1);
        newObsBlock_down = Instantiate(tempBlock, new Vector3(obstaclePos + ranNumArrDown, setY, 0), Quaternion.Euler(setEuler * 180, 0, 0));
        newObsBlock_down.SetParent(transform);
    }   // CreateObstacle()

    void RandomObstacle(int pos)    // 랜덤 장애물 생성
    {
        tempBlock = boxObstacle;
        CheckObstacle(pos, 1);
    }   // RandomObstacle(Transform tempBlock, int pos, float setY)

    void CheckObstacle(int pos, int checkNum)   // 장애물 위치 설정
    {
        if (pos == 1)
        {
            SetUpObsPos(checkNum);
        }
        else
        {
            SetDownObsPos(checkNum);
        }
    }   // checkObstacle(int pos, int checkNum)

    void SetUpObsPos(int checkNum)  // 윗 장애물 위치 설정
    {
        if (checkNum == 1)
        {
            setY = 2.01f;
        }
    }   // SetUpObsPos(int checkNum)

    void SetDownObsPos(int checkNum)    // 아랫 장애물 위치 설정
    {
        if (checkNum == 1)
        {
            setEuler = 1;
            setY = -0.0f;
        }
    }   // SetDownObsPos(int checkNum)

    void CreateMoveObstacle()
    {
        float randomMove_up = Random.Range(3.0f, 5.5f);
        newObsBlock_up = Instantiate(flyerObstacle, new Vector3(obstaclePos, randomMove_up, 0), Quaternion.identity);
        newObsBlock_up.SetParent(transform);

        float randomMove_down = Random.Range(-1.0f, -2.5f);
        newObsBlock_down = Instantiate(fishObstacle, new Vector3(obstaclePos + 10, randomMove_down, 0), Quaternion.identity);
        newObsBlock_down.SetParent(transform);

        Player.isHiting = false;
    }

}   // Obstacle Class
