using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayer : MonoBehaviour
{
    public GameObject enemy;
    int posX = 0;
    int posY = 0;
    public void CubeCreate()
    {
        Instantiate(enemy, new Vector3(posX++, posY, 0), Quaternion.identity);
        if (posX%10==0)
        {
            posY++;
            posX = 0;
        }
    }
    // 버튼 누르면 큐브 하나씩 생성됨
}