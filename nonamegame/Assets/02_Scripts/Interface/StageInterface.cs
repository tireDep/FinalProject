using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageInterface : MonoBehaviour
{
    public Canvas basicUI;

    void Start()
    {
        CloseHowToPlay();
    }   // Start()

    public void OpenHowToPlay()
    {
        basicUI.enabled = false;
    }   // OpenHowToPlay()

    public void CloseHowToPlay()
    {
        basicUI.enabled = true;
    }   // CloseHowToPlay()

}   // StageInterface Class
