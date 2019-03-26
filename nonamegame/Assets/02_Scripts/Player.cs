using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();      //Rigidbody 컴포넌트를 받아옴
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(5f * Time.deltaTime, 0f, 0f);
        // 플레이어 자동 이동

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
            transform.Translate(Vector3.up*2);
            // 2단 점프도 생각해볼것
        }
    }
}
