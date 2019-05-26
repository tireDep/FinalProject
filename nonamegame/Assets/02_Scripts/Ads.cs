using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{
    public static void PlayAds()
    {
        if(Advertisement.IsReady() && DataManager.checkPlay == 3)
        {
            DataManager.checkPlay = 0;
            Advertisement.Show();
        }
    }
}
