using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageInterface : MonoBehaviour
{
    public Canvas basicUI;
    public Canvas imgUI;

    void Start()
    {
        CloseHowToPlay();
    }   // Start()

    public void OpenHowToPlay()
    {
        basicUI.enabled = false;
        imgUI.enabled = true;
    }   // OpenHowToPlay()

    public void CloseHowToPlay()
    {
        imgUI.enabled = false;
        basicUI.enabled = true;
    }   // CloseHowToPlay()

}   // StageInterface Class
