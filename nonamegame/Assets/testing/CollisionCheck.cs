using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    private void Update()
    {
        Move();
    }

    int checkpos = -1; // 위아래 이동 변수
    public int speed = 10;
    void Move()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up* speed *Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            //checkpos = transform.position.y > 0 ? -1 : 1;
            if(checkpos==-1)
            {
                checkpos = 1;
                transform.Translate(Vector3.down * 5);
            }
            else
            {
                checkpos = -1;
                transform.Translate(Vector3.up * 5);
            }
        }
    }

    Material material;
    Color baseColor;
    void OnCollisionEnter(Collision collision)
    {
        material.color = Color.yellow;
    }

    void OnCollisionExit(Collision collision)
    {
        material.color = baseColor;
    }

}
