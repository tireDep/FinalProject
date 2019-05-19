using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class SwipeReceiver : MonoBehaviour
{
    //override this
    protected virtual void OnSwipeLeft()
    {

    }

    //override this
    protected virtual void OnSwipeRight()
    {

    }

    //override this
    protected virtual void OnSwipeUp()
    {

    }

    //override this
    protected virtual void OnSwipeDonw()
    {

    }

    protected virtual void Update()
    {
        if (!Game.isPause && EventSystem.current.IsPointerOverGameObject() == false)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Player.CheckPlayerPos();
            }
            else
            {
                if (SwipeManager.Instance.IsSwiping(SwipeManager.SwipeDirection.Right))
                {
                    OnSwipeRight();
                }

                if (SwipeManager.Instance.IsSwiping(SwipeManager.SwipeDirection.Left))
                {
                    OnSwipeLeft();
                }

                if (SwipeManager.Instance.IsSwiping(SwipeManager.SwipeDirection.Up))
                {
                    OnSwipeUp();
                }

                if (SwipeManager.Instance.IsSwiping(SwipeManager.SwipeDirection.Down))
                {
                    OnSwipeDonw();
                }
            }
        }
    }

}
