using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigidBody;    // 물리변수
    private bool playerPos; // 플레이어 위치
    /* maybe : 양방향도 추가될 수 있음 -> int형 수정? */
    private bool isGround;  // 바닥 체크

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();      //Rigidbody 컴포넌트를 받아옴
        playerPos = true;   // 위에 위치
        isGround = true;    // 점프 가능
    }   // Start()

    void Update()
    {
        Move();
    }   // Update()

    private void Move() // 플레이어 이동 관련
    {
        transform.Translate(5f * Time.deltaTime, 0f, 0f);   // 플레이어 자동 이동

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerJump();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.DownArrow))
        {
            CheckPlayerPos();
        }
    }   // Move()

    private void PlayerJump()   // 플레이어 점프
    {
        if(isGround)
        {
            //isGround = false;
            if (playerPos)
            {
                rigidBody.AddForce(Vector3.up * 23, ForceMode.Impulse);
            }
            else
            {
                rigidBody.AddForce(Vector3.down * 23, ForceMode.Impulse);
            }
        }
    }   // PlayerJump()

    private void CheckPlayerPos()   // 플레이어 위치 판별
    {
        if (playerPos == true)  // 위에서 아래로
        {
            playerPos = false;
            Physics.gravity = Vector3.up * 100;
            transform.Translate(Vector3.down * 2);
        }
        else if(playerPos == false) // 아래에서 위로
        {
            playerPos = true;
            Physics.gravity = Vector3.down * 100;
            transform.Translate(Vector3.up * 2);
        }
    }   // CheckPlayerPos()

    // 점프 횟수 제한 관련
    /* maybe : 점프 빠르게 연타하면 에러나는듯? 확인 필요함! */
    void OnCollisionEnter(Collision collision)  // 처음 부딪혔을 경우
    {
        if (collision.transform.tag == "Ground")
        {
            isGround = true; //바닥과 맞닿아 있음(점프 가능)
        }
    }   // OnCollisionEnter(Collision collision)

    void OnCollisionStay(Collision collision)   // 부딪힌 상태 유지
    {
        if (collision.transform.tag == "Ground")
        {
            isGround = true; //바닥과 맞닿아 있음(점프 가능)
        }
    }   // OnCollisionStay(Collision collision)   

    void OnCollisionExit(Collision collision)    // 콜라이더 떨어져 있을 때
    {
        if (collision.transform.tag == "Ground")
        {
            isGround = false; //바닥과 맞닿아 있지 않음(점프 불가능)
        }
    }   // OnCollisionExit(Collision collision)    

}   // Class
