using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Game game;
    private void Start()
    {
        game = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();
    }   //  Start()

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            game.lastCheckPointPos = transform.position;
            // !수정예정! - 음악, 지형, 장애물, 카메라 다 받아와야 함
        }
    }   //  OnTriggerEnter(Collider other)

}   // CheckPoint Class
