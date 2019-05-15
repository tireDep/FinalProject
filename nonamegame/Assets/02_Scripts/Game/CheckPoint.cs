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

    public static float checkPointPos;  // 체크포인트 위치
    private void OnTriggerEnter(Collider other) // 충돌체크
    {
        if (other.CompareTag("Player"))  // 플레이어와 부딪혔을 때, 현재 상태 저장
        {
            Player.isPlayerCheckPoint = true;   // 체크포인트를 지났으므로 삭제 가능

            game.lastCheckPointPos = transform.position;
            game.lastCheckCamera = Camera.main.transform.position;
            game.lastCheckCamera.x = game.lastCheckPointPos.x + 4.0f; ;  // 카메라 밀림 방지
            game.lastCheckAudio = Audio.slider.value;

            Game._bsCnt = DataManager.bsCnt;    //   화면 삭제 변수 초기화
        }
    }   //  OnTriggerEnter(Collider other)

    private void OnTriggerExit(Collider other)
    {
        Player.isPlayerCheckPoint = false;  // 삭제  불가능
    }   // OnTriggerExit(Collider other)

}   // CheckPoint Class
