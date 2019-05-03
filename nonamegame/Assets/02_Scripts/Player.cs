using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Scene change

public class Player : MonoBehaviour
{
    /*
     플레이어 조작 관련 스크립트
     - 이동 함수
     - 점프 함수
     - 위치 함수
     - 충돌 체크 함수
     - 충돌 체크(점수 계산)
    */

    private Rigidbody rigidBody;    // 물리기능 이용 
    public static SpriteRenderer spriteRenderer;  // filp 기능 이용
    private bool isGround;  // 바닥 체크
    public static bool playerPos; // 플레이어 위치
    /* !수정예정! - 양방향도 추가될 수 있음 -> int형 수정? */

    private float moveSpeed = 10.0f; // 이동속도 변수
    private float jumpPower = 27.0f; // 점프 힘 변수 /*!수정예정! - 그냥 점프가 수정되야될거같기도 하고*/
    public static int gravityForce = 100; // 중력변수
    public static int setPos = 2; // 플레이어 위치
    public static bool isDead;    // 생사여부

    float playTime; // 플레이 시간

    public static int playerHitCount; //   충돌횟수

    public static bool isPlayerCheckPoint;  // 플레이어 체크포인트 지나침 확인

    void Start()
    {
        Physics.gravity = Vector3.down * 100;   // 시작시 공중뜨는거 방지
        rigidBody = GetComponent<Rigidbody>();      // Rigidbody 컴포넌트를 받아옴
        spriteRenderer = GetComponent<SpriteRenderer>();    // SpriteRenderer 컴포넌트 받아옴
        playerPos = true;   // 위에 위치
        isGround = true;    // 점프 가능   

        isDead = false; // 생사여부

        playTime = 0f;  // 플레이 시간

        playerHitCount = 0; // 부딪힘 초기화

        isPlayerCheckPoint = false; // 체크포인트를 지나지 x
    }   // Start()

    //float nowChekcPointPos = 0; // 체크포인트 위치 저장
    void Update()
    {
        playTime += Time.deltaTime; // 플레이 시간 누적
        if (!Game.isPause)
        {
            AutoMove();
            InputMove();
        }

        //Debug.Log(CheckPoint.checkPointPos + "//" + nowChekcPointPos);
        /*if(CheckPoint.checkPointPos > nowChekcPointPos)
        {
            nowChekcPointPos = CheckPoint.checkPointPos;
            
            // 플레이어가 생성된 체크 포인트를 지나쳤을 때 이전 블록 삭제
        }*/

    }   // Update()

    public void AutoMove()  // 플레이어 자동 이동
    {
        transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f);
    }   // AutoMove()

    public void InputMove() // 플레이어 입력 이동
    {
        if (Input.GetKeyDown(KeyCode.Space))    // 점프
        {
            PlayerJump();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))   //   위치 변환
        {
            CheckPlayerPos();
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) // 화면 삭제
        {
            Game.BlueScreenOn();
        }
    }   // InputMove() 

    bool rockChangePos = false; // 점프 중 위치 변환 x
    private void PlayerJump()   // 플레이어 점프
    {
        if (isGround)   // 땅에 위치할 경우
        {
            if (playerPos)
            {
                rigidBody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }
            else
            {
                rigidBody.AddForce(Vector3.down * jumpPower, ForceMode.Impulse);
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
            Physics.gravity = Vector3.up * gravityForce;
            transform.Translate(Vector3.down * setPos);
        }
        else if (playerPos == false && rockChangePos == true) // 아래에서 위로
        {
            playerPos = true;
            spriteRenderer.flipY = false;
            Physics.gravity = Vector3.down * gravityForce;
            transform.Translate(Vector3.up * setPos);
        }
    }   // CheckPlayerPos()

    /* 
     물체 충돌 관련 함수들
     - 점프 횟수 설정(1번만 가능)
     - 위치 변경 설정(점프 중 불가능)
     - 장애물과 부딪혔을 경우
    */

    void OnCollisionEnter(Collision collision)  // 처음 부딪혔을 경우
    {
        if (collision.transform.tag == "Ground")
        {
            isGround = true; // 바닥과 맞닿아 있음(점프 가능)
            rockChangePos = true;   // 위치변경 가능
        }
    }   // OnCollisionEnter(Collision collision)    

    void OnCollisionStay(Collision collision)   // 부딪힌 상태 유지
    {
        if (collision.transform.tag == "Ground")
        {
            isGround = true; //바닥과 맞닿아 있음(점프 가능)
            rockChangePos = true; // 위치변경 가능
        }
    }   // OnCollisionStay(Collision collision)   

    void OnCollisionExit(Collision collision)    // 콜라이더 떨어져 있을 때
    {
        if (collision.transform.tag == "Ground")
        {
            isGround = false; //바닥과 맞닿아 있지 않음(점프 불가능)
            rockChangePos = false;  // 위치변경 불가능
        }
    }   // OnCollisionExit(Collision collision)

    /*
     isTriger를 이용, hitCount 체크
    */

    bool isNoHit = false;   // 부딪침 체크
    private void OnTriggerEnter(Collider other) // 장애물과 부딪혔을 경우
    {
        if (other.transform.tag == "Obstacle" && !isNoHit /*&& other.isTrigger*/ )
        {
            isNoHit = true;
            StartCoroutine("NoHitTime");
            playerHitCount++;   // 부딪힐 경우 증가
            GetComponent<PlayerPos>().PlayerCheckPoint();
        }   // 충돌 체크 시 카운트 증가 -> Game.cs에서 점수 차감
    }   // OnTriggerEnter(Collider other)

    IEnumerator NoHitTime() // 무적시간용 코루틴 함수
    {
        int countTime = 0;

        while(countTime<10)
        {
            if(countTime%2==0)
            {
                spriteRenderer.color = new Color32(255, 255, 255, 90);
            }
            else
            {
                spriteRenderer.color = new Color32(255, 255, 255, 180);
            }
            // 무적인 동안 깜빡임 효과
            yield return new WaitForSeconds(0.15f);
            countTime++;
        }

        spriteRenderer.color = new Color32(255, 255, 255, 255);
        isNoHit = false;
        yield return null;
    }   // IEnumerator NoHitting()

}   // Player Class
