using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileSwipe : SwipeReceiver
{
    protected override void OnSwipeUp()
    {
        base.OnSwipeUp();
        Player.PlayerJump();
    }

    protected override void OnSwipeDonw()
    {
        base.OnSwipeDonw();
        Player.PlayerJump();
    }

    /*protected override void OnSwipeLeft()
    {
        base.OnSwipeLeft();
        Player.CheckPlayerPos();
    }

    protected override void OnSwipeRight()
    {
        base.OnSwipeRight();
        Player.CheckPlayerPos();
    }*/

}
