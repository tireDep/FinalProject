using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public Player player;

    public void WhenClick()
    {
        player.transform.Translate(-10,1,0);
    }
}
