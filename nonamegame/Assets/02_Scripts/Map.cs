using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private Transform[] testArr = new Transform[10];
    int i = 0;

    public Transform mapBlock;  // 프리팹
    private Transform newMapBlock;  // 맵 생성
    private int makeBlock = 0;  // 맵 개수 변수
    int testcnt = 0;

    public void CreateMap()    // 기본 1자 바닥 생성
    {
        newMapBlock = Instantiate(mapBlock, new Vector3(makeBlock++, 1, 0), Quaternion.identity);
        testcnt++;
        if(testcnt%10==0)
        {
            CreateObstacle(makeBlock);
        }
        
        /*testArr[i] = newMapBlock; 

        if(i==10)
        {
            DeleteMap();
        }
        else
        {
            i++;
        }*/
    }   // CreateMap()

    public Transform obstacleBlock;
    public Transform obstacleBlock_2;
    public Transform obstacleBlock_3;
    Transform newObsBlock_up;
    Transform newObsBlock_down;
    Transform tempBlock;
    float setY = 0;
    void CreateObstacle(int makeBlock)    // 장애물 생성
    {
        RandomObstacle(1);
        newObsBlock_up = Instantiate(tempBlock, new Vector3(makeBlock+5, setY, 0), Quaternion.identity);
        RandomObstacle(-1);
        newObsBlock_down = Instantiate(tempBlock, new Vector3(makeBlock+10, setY, 0), Quaternion.Euler(180,0,0));
    }   // CreateObstacle()

    void RandomObstacle(int pos)
    {
        int randomObstacle = Random.Range(1, 4);

        switch (randomObstacle)
        {
            case 1:
                tempBlock = obstacleBlock;
                CheckObstacle(pos, 1);
                break;

            case 2:
                tempBlock = obstacleBlock_2;
                CheckObstacle(pos, 2);
                break;

            case 3:
                tempBlock = obstacleBlock_3;
                CheckObstacle(pos, 3);
                break;

            default:
                tempBlock = obstacleBlock;
                CheckObstacle(pos, 1);
                break;
        }
    }   // RandomObstacle(Transform tempBlock, int pos, float setY)

    void CheckObstacle(int pos, int checkNum)
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

    void DeleteMap()
    {
        /*Destroy(testArr[0].gameObject);
        for (int i = 0; i < 9; i++)
        {
            testArr[i] = testArr[i++];
        }*/
    }   // DeleteMap()

}   // Map Class
