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
     - Hp 체크 및 초기화
    */

    private Rigidbody rigidBody;    // 물리기능 이용 
    private SpriteRenderer spriteRenderer;  // filp 기능 이용
    private bool isGround;  // 바닥 체크
    private bool playerPos; // 플레이어 위치
    /* !수정예정! - 양방향도 추가될 수 있음 -> int형 수정? */

    //int maxplayerHp = 3; // MaxHP
    //public static int playerHp;    // HP
    private float moveSpeed = 10.0f; // 이동속도 변수
    private float jumpPower = 27.0f; // 점프 힘 변수 /*!수정예정! - 그냥 점프가 수정되야될거같기도 하고*/
    private int gravityForce = 100; // 중력변수
    private int setPos = 2; // 플레이어 위치
    public static bool isDead;    // 생사여부

    float playTime; // 플레이 시간
    void Start()
    {
        Physics.gravity = Vector3.down * 100;   // 시작시 공중뜨는거 방지
        rigidBody = GetComponent<Rigidbody>();      // Rigidbody 컴포넌트를 받아옴
        spriteRenderer = GetComponent<SpriteRenderer>();    // SpriteRenderer 컴포넌트 받아옴
        playerPos = true;   // 위에 위치
        isGround = true;    // 점프 가능   

        //playerHp = maxplayerHp;   // HP 설정
        isDead = false; // 생사여부

        playTime = 0f;
    }   // Start()

    void Update()
    {
        playTime += Time.deltaTime; // 플레이 시간 누적
        if(!Game.isPause)
        {
            Move();
            ResetPlayerLife();
        }
    }   // Update()

    /*private void FixedUpdate()
    {
        
    }
    // !수정예정? ! - FixedUpdate() 분리?*/

    //Animator animator;
    public void Move() // 플레이어 이동 관련
    {
        //animator = GetComponent<Animator>();
        transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f); // 플레이어 자동 이동

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

    public static bool isSavePoint = false; // 세이브포인트 확인
    int checkTime = 0;  // 초기화 시간 체크
    void ResetPlayerLife()  // 특정 시간이 지나면 플레이어 Hp 초기화
    {
        // Debug.Log(playTime + " / " + Audio.playTime_25);
        if((Audio.playTime_25 == (int)playTime || Audio.playTime_50 == (int)playTime || Audio.playTime_75 == (int)playTime) && !isSavePoint)
        {
            isSavePoint = true;
            //GetComponent<Map>().CreateResetPoint(); /* !수정예정! - 그래픽적으로 보여져야 함 */
            //playerHp = maxplayerHp;
            checkTime = (int)playTime;  // 초기화는 한번만 실행되어야 함
           // Debug.Log("resetLIfe");
        }

        if ((int)playTime > checkTime)
        {
            isSavePoint = false;
        }
    }   // ResetPlayerLife()

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

    bool isNoHit = false;
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
     isTriger를 이용, HP 체크 
    */

    private void OnTriggerEnter(Collider other) // 장애물과 부딪혔을 경우
    {
        if (other.transform.tag == "Obstacle" && !isNoHit /*&& other.isTrigger*/ )
        {
            /*playerHp--;
            if (playerHp < 0)
            {
                isDead = true;
            }
            else*/
            {
                isNoHit = true;
                StartCoroutine("NoHitting");
            }
            //Debug.Log(playerHp);/*!수정예장! -> 삭제*/
        }   // 충돌 임시 체크 !수정예정! -> 세이브 포인트 등으로 + Life 초기화
    }   // OnTriggerEnter(Collider other)

    IEnumerator NoHitting() // 무적시간용 코루틴 함수
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
