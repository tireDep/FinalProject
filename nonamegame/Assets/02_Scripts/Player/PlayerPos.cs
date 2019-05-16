using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerPos : MonoBehaviour
{
    /*
     체크포인트 관련 스크립트
     - 체크포인트 위치 설정
    */
    private Game game;

    private void Start()
    {
        game = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();
        SetCheckPoint();
    }   //   Start()

    void SetCheckPoint()    // 체크포인트 설정
    {
        transform.position = game.lastCheckPointPos;
        Camera.main.transform.position = game.lastCheckCamera;
        if (null != Audio.slider)
        {
            Audio.slider.value = game.lastCheckAudio;
        }
    }   // SetCheckPoint()

    public void PlayerCheckPoint()  // 체크포인트 정보 저장
    {
        SetCheckPoint();

        Player.playerPos = true;
        Player.spriteRenderer.flipY = false;
        Physics.gravity = Vector3.down * Player._gravityForce;
        transform.Translate(Vector3.up * Player._setPos);
        // 추락사 방지용
    }   // PlayerCheckPoint()

}   // PlyaerPos Class
