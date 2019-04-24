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

    public Text scoreText;
    public Text rankText;
    // UI 변수들

    int playerScore; // 플레이어 점수
    int maxScore;   // 최고점수
    int checkRank;    // 랭크 계산

    void Start()
    {
        playerScore = Game.playerScore;
        maxScore = Game.maxScore;
        checkRank = Game.maxScore / 10;

        CheckRank();
    }   // Start()

    void CheckRank()
    {
        if(playerScore==maxScore)
        {
            scoreText.text = playerScore.ToString();
            rankText.text = "NoHitPlay";
        }
        else if(playerScore >= maxScore - checkRank && playerScore < maxScore)
        {
            scoreText.text = playerScore.ToString();
            rankText.text = "A";
        }
        else if (playerScore >= maxScore - checkRank * 2 && playerScore < maxScore - checkRank)
        {
            scoreText.text = playerScore.ToString();
            rankText.text = "B";
        }
        else if (playerScore >= maxScore - checkRank * 3 && playerScore < maxScore - checkRank * 2)
        {
            scoreText.text = playerScore.ToString();
            rankText.text = "C";
        }
        else if (playerScore >= maxScore - checkRank * 4 && playerScore < maxScore - checkRank * 3)
        {
            scoreText.text = playerScore.ToString();
            rankText.text = "D";
        }
        else
        {
            scoreText.text = playerScore.ToString();
            rankText.text = "F";
        }
    }   // CheckRank()

}   // Result Class
