using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Transform boxObstacle;
    public Transform snailObstacle;
    public Transform longObstacle;
    public Transform flyerObstacle;
    public Transform fishObstacle;
    public Transform slimeObstacle;
    // 장애물 종류
    float passTime = 0;

    int obstaclePos;
    private void Update()
    {
        obstaclePos = Map.makeBlock;
        if(Map.isObsCreate)
        {
            CreateObstacle(obstaclePos);
            Map.isObsCreate = false;
        }

        //passTime += Time.deltaTime;
        //if(Player.isHiting)//(passTime >= 1.0f)
        //{
            //passTime = 0;
       //     CreateMoveObstacle();
       // }
    }

    Transform newObsBlock_up;
    Transform newObsBlock_down;
    // 장애물 생성 위치

    Transform tempBlock;    // 생성할 장애물 설정
    float setY = 0; // 장애물 위치  설정
    int setEuler = 0;   // 장애물 뒤집기 유무 설정
    void CreateObstacle(int makeBlock)    // 장애물 생성
    {
        int rndCnt = Random.Range(1, 5);
        RandomObstacle(1);
        newObsBlock_up = Instantiate(tempBlock, new Vector3(makeBlock + rndCnt, setY, 0), Quaternion.identity);
        rndCnt = Random.Range(10,16);
        RandomObstacle(-1);
        newObsBlock_down = Instantiate(tempBlock, new Vector3(makeBlock + rndCnt, setY, 0), Quaternion.Euler(setEuler * 180, 0, 0));
    }   // CreateObstacle()


    void RandomObstacle(int pos)    // 랜덤 장애물 생성
    {
        // int pos : 장애물 생성 위치
        int randomObstacle = Random.Range(1, 5);

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
                if (pos > 0)
                {
                    tempBlock = snailObstacle;
                }
                else
                {
                    tempBlock = slimeObstacle;
                }
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
        else if (checkNum == 2)
        {
            setY = 2.96f;
        }
        else if (checkNum == 3)
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
            setEuler = 1;
            setY = 0.24f;
        }
    }   // SetDownObsPos(int checkNum)

    void CreateMoveObstacle()
    {
        float randomMove_up = Random.Range(2.0f, 5.5f);
        float playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        newObsBlock_up = Instantiate(flyerObstacle, new Vector3(playerPosition + 10, 2.0f, 0), Quaternion.identity);

        float randomMove_down = Random.Range(-0.0f, -2.5f);
        newObsBlock_down = Instantiate(fishObstacle, new Vector3(playerPosition + 15, 0f, 0), Quaternion.identity);

        Player.isHiting = false;
    }

}   // Obstacle Class
