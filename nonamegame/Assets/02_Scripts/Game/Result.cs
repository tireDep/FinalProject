using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Scene change
using UnityEngine.UI;   // UI

public class Result : MonoBehaviour
{
    /*
     게임결과 계산 스크립트
     - 플레이어의 점수 및 랭크 계산 출력
     */

    public Text hitCntText;
    public Text scoreText;
    // UI 변수들

    void Start()
    {
        CheckScore();
    }   // Start()

    void CheckScore()
    {
        hitCntText.text = Game.checkHitCount.ToString();
        scoreText.text= Game.setPlayerScoreUI.ToString();
    }   // CheckScore()

}   // Result Class
