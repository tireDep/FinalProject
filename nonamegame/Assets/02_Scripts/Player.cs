using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Scene change

public class Player : MonoBehaviour
{
    private Rigidbody rigidBody;    // 물리변수
    private bool playerPos; // 플레이어 위치
    /* maybe : 양방향도 추가될 수 있음 -> int형 수정? */
    private bool isGround;  // 바닥 체크
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        Physics.gravity = Vector3.down * 100;   // 시작시 공중뜨는거 방지
        rigidBody = GetComponent<Rigidbody>();      //Rigidbody 컴포넌트를 받아옴
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerPos = true;   // 위에 위치
        isGround = true;    // 점프 가능   
    }   // Start()

    void Update()
    {
        if(!Game.isPause)
        {
            Move();
        }
    }   // Update()

    //Animator animator;
    public void Move() // 플레이어 이동 관련
    {
        //animator = GetComponent<Animator>();
        transform.Translate(5f * Time.deltaTime, 0f, 0f);   // 플레이어 자동 이동 !수정될 수 있는 값!

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerJump();
            //   animator.SetTrigger("Jumping");
        }
        //animator.SetTrigger("Running");

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            CheckPlayerPos();
        }
    }   // Move()

    private void PlayerJump()   // 플레이어 점프
    {
        if (isGround)
        {
            if (playerPos)
            {
                rigidBody.AddForce(Vector3.up * 30, ForceMode.Impulse);
            }
            else
            {
                rigidBody.AddForce(Vector3.down * 30, ForceMode.Impulse);
            }
        }
        rockChangePos = false;
    }   // PlayerJump()

    private void CheckPlayerPos()   // 플레이어 위치 판별
    {
        if (playerPos == true && rockChangePos == true)  // 위에서 아래로
        {
            playerPos = false;
            spriteRenderer.flipY = true;
            Physics.gravity = Vector3.up * 100;
            transform.Translate(Vector3.down * 2);
        }
        else if (playerPos == false && rockChangePos == true) // 아래에서 위로
        {
            playerPos = true;
            spriteRenderer.flipY = false;
            Physics.gravity = Vector3.down * 100;
            transform.Translate(Vector3.up * 2);
        }
    }   // CheckPlayerPos()

    // 점프 횟수 제한 관련
    bool rockChangePos = false; // 점프 중 위치 변환 x
    void OnCollisionEnter(Collision collision)  // 처음 부딪혔을 경우
    {
        if (collision.transform.tag == "Ground")
        {
            isGround = true; //바닥과 맞닿아 있음(점프 가능)
            rockChangePos = true;
        }

        if (collision.transform.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOver");
        }   // 충돌 임시 체크

    }   // OnCollisionEnter(Collision collision)

    void OnCollisionStay(Collision collision)   // 부딪힌 상태 유지
    {
        if (collision.transform.tag == "Ground")
        {
            isGround = true; //바닥과 맞닿아 있음(점프 가능)
            rockChangePos = true;
        }
    }   // OnCollisionStay(Collision collision)   

    void OnCollisionExit(Collision collision)    // 콜라이더 떨어져 있을 때
    {
        if (collision.transform.tag == "Ground")
        {
            isGround = false; //바닥과 맞닿아 있지 않음(점프 불가능)
            rockChangePos = false;
        }
    }   // OnCollisionExit(Collision collision)

}   // Class
