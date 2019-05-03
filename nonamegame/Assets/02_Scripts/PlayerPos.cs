using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerPos : MonoBehaviour
{
    private Game game;

    private void Start()
    {
        game = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();
        transform.position = game.lastCheckPointPos;
        Camera.main.transform.position = game.lastCheckCamera;
        Audio.slider.value = game.lastCheckAudio;   // 이거 왜 에러날까...
    }   //   Start()

    public void PlayerCheckPoint()  // 체크포인트 정보 저장
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // 씬 재시작인데 이거로 하면 화면 UI가 화면 가려서 작동x
        transform.position = game.lastCheckPointPos;
        Camera.main.transform.position = game.lastCheckCamera;
        Audio.slider.value = game.lastCheckAudio;

        Player.playerPos = true;
        Player.spriteRenderer.flipY = false;
        Physics.gravity = Vector3.down * Player.gravityForce;
        transform.Translate(Vector3.up * Player.setPos);
        // 추락사 방지용 -> 수정 및 삭제 예정
    }   // PlayerCheckPoint()

}   // PlyaerPos Class
