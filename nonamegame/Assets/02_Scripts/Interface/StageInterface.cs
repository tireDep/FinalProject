using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageInterface : MonoBehaviour
{
    public Canvas basicUI;
    public Canvas highScoreUI;

    public Text highScore_1;
    public Text highScore_2;
    public Text highScore_3;
    public Text highScore_4;
    public Text highScore_5;

    void Start()
    {
        // ResetScore();

        Ads.PlayAds();
        CheckScore();
        highScoreUI.enabled = false;
    }   // Start()

    public void ResetScore()
    {
        PlayerPrefs.SetInt("StageScore_01", 1);
        PlayerPrefs.SetInt("StageScore_02", 1);
        PlayerPrefs.SetInt("StageScore_03", 1);
        PlayerPrefs.SetInt("StageScore_04", 1);
        PlayerPrefs.SetInt("StageScore_05", 1);

        CheckScore();
    }   // ResetScore()

    void CheckScore()
    {
        if(PlayerPrefs.GetFloat("StageScore_01") == 1)
        {
            highScore_1.text = "0";
        }
        else
        {
            highScore_1.text = PlayerPrefs.GetFloat("StageScore_01").ToString();
        }

        if (PlayerPrefs.GetFloat("StageScore_02") == 1)
        {
            highScore_2.text = "0";
        }
        else
        {
            highScore_2.text = PlayerPrefs.GetFloat("StageScore_02").ToString();
        }

        if (PlayerPrefs.GetFloat("StageScore_01") == 1)
        {
            highScore_1.text = "0";
        }
        else
        {
            highScore_1.text = PlayerPrefs.GetFloat("StageScore_01").ToString();
        }

        if (PlayerPrefs.GetFloat("StageScore_02") == 1)
        {
            highScore_2.text = "0";
        }
        else
        {
            highScore_2.text = PlayerPrefs.GetFloat("StageScore_02").ToString();
        }

        if (PlayerPrefs.GetFloat("StageScore_01") == 1)
        {
            highScore_1.text = "0";
        }
        else
        {
            highScore_1.text = PlayerPrefs.GetFloat("StageScore_01").ToString();
        }

        if (PlayerPrefs.GetFloat("StageScore_03") == 1)
        {
            highScore_3.text = "0";
        }
        else
        {
            highScore_3.text = PlayerPrefs.GetFloat("StageScore_03").ToString();
        }

        if (PlayerPrefs.GetFloat("StageScore_04") == 1)
        {
            highScore_4.text = "0";
        }
        else
        {
            highScore_4.text = PlayerPrefs.GetFloat("StageScore_04").ToString();
        }

        if (PlayerPrefs.GetFloat("StageScore_05") == 1)
        {
            highScore_5.text = "0";
        }
        else
        {
            highScore_5.text = PlayerPrefs.GetFloat("StageScore_05").ToString();
        }
    }

    public void OpenToHighScore()
    {
        basicUI.enabled = false;
        highScoreUI.enabled = true;
    }   // OpenToHighScore()

    public void CloseToHighScore()
    {
        basicUI.enabled = true;
        highScoreUI.enabled = false;
    }   // CloseToHighScore()

}   // StageInterface Class
