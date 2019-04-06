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
    Transform newObsBlock_up;
    Transform newObsBlock_down;
    void CreateObstacle(int makeBlock)    // 장애물 생성
    {
        newObsBlock_up = Instantiate(obstacleBlock, new Vector3(makeBlock+5, 2, 0), Quaternion.identity);
        newObsBlock_down = Instantiate(obstacleBlock, new Vector3(makeBlock+10, 0, 0), Quaternion.identity);
    }   // CreateObstacle()

    void DeleteMap()
    {
        /*Destroy(testArr[0].gameObject);
        for (int i = 0; i < 9; i++)
        {
            testArr[i] = testArr[i++];
        }*/
    }   // DeleteMap()

}   // Map Class
