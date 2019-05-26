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
        /*PlayerPrefs.SetInt("StageScore_01", 0);
        PlayerPrefs.SetInt("StageScore_02", 0);
        PlayerPrefs.SetInt("StageScore_03", 0);
        PlayerPrefs.SetInt("StageScore_04", 0);
        PlayerPrefs.SetInt("StageScore_05", 0);*/

        highScore_1.text = PlayerPrefs.GetFloat("StageScore_01").ToString();
        highScore_2.text = PlayerPrefs.GetFloat("StageScore_02").ToString();
        highScore_3.text = PlayerPrefs.GetFloat("StageScore_03").ToString();
        highScore_4.text = PlayerPrefs.GetFloat("StageScore_04").ToString();
        highScore_5.text = PlayerPrefs.GetFloat("StageScore_05").ToString();

        highScoreUI.enabled = false;
    }   // Start()

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
