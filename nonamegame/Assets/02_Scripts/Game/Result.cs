using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Scene change
using UnityEngine.UI;   // UI

public class Result : MonoBehaviour
{
    public Text hitCntText;
    public Text scoreText;

    public Text highScoreText;
    // UI 변수들

    void Start()
    {
        CheckScore();
    }   // Start()

    void CheckScore()
    {
        highScoreText.text = "";
        if (DataManager.CheckHighScore())
        {
            highScoreText.text = "new\nhighScore!";
            hitCntText.text = Game.checkHitCount.ToString();
            scoreText.text = Game.setPlayerScoreUI.ToString();
        }
        else
        {
            hitCntText.text = Game.checkHitCount.ToString();
            scoreText.text = Game.setPlayerScoreUI.ToString();
        }
    }   // CheckScore()

}   // Result Class
