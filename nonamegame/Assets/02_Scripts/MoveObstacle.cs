using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    void Update()
    {
        Move();
    }   // Update()

    void Move()
    {
        transform.Translate(-2f * Time.deltaTime, 0f, 0f);
    }   // Move()

}   // MoveObstacle Class
