using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileSwipe : MonoBehaviour
{
    /*  private Vector3 fp;   //First touch position	
      private Vector3 lp;   //Last touch position	
      private float dragDistance;  //minimum distance for a swipe to be registered	

      void Start()
      {
          dragDistance = Screen.height * 15 / 100; //dragDistance is 15% height of the screen	
      }

      private void Update()
      {
          if (!Game.isPause && EventSystem.current.IsPointerOverGameObject() == false)
          {
              if (Input.touchCount == 1)
              {
                  Touch touch = Input.GetTouch(0);

                  if (touch.phase == TouchPhase.Began)
                  {
                      fp = touch.position;
                      lp = touch.position;
                  }

                  else if (touch.phase == TouchPhase.Moved)
                  {
                      lp = touch.position;
                  }

                  else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen	
                  {
                      lp = touch.position;  //last touch position. Ommitted if you use list	

                      //Check if drag distance is greater than 20% of the screen height	
                      if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                      {//It's a drag	
                       //check if the drag is vertical or horizontal	
                          if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                          {   //If the horizontal movement is greater than the vertical movement...	
                              if ((lp.x > fp.x))  //If the movement was to the right)	
                              {   //Right swipe	
                                  Debug.Log("Right Swipe");
                              }
                              else
                              {   //Left swipe	
                                  Debug.Log("Left Swipe");
                              }

                          }
                          else
                          {   //the vertical movement is greater than the horizontal movement	
                              if (lp.y > fp.y)  //If the movement was up	
                              {   //Up swipe	
                                  Debug.Log("Up Swipe");
                              }
                              else
                              {   //Down swipe	
                                  Debug.Log("Down Swipe");
                              }

                          }
                          //Game.BlueScreenOn();
                      }
                      else
                      {   //It's a tap as the drag distance is less than 20% of the screen height	

                          float camWidth = Camera.main.pixelWidth / 2;


                              if (touch.position.x > camWidth && EventSystem.current.IsPointerOverGameObject() == false)
                              {
                                  Player.CheckPlayerPos();
                              }
                              else if(touch.position.x < camWidth && EventSystem.current.IsPointerOverGameObject() == false)
                              {
                                  Player.PlayerJump();
                              }

                          Debug.Log("Tap");
                          // Player.CheckPlayerPos();
                      }
                  }
              }
          }
      }*/

    private Touch tempTouchs;
    // private Vector3 touchedPos;

    Camera camera;
    private void Update()
    {
        /*if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (EventSystem.current.IsPointerOverGameObject(i) == false)
                {
                    tempTouchs = Input.GetTouch(i);

                    if (tempTouchs.phase == TouchPhase.Began)
                    {
                        // touchedPos = Camera.main.ScreenToWorldPoint(tempTouchs.position);


                        if (tempTouchs.position.x > Camera.main.pixelWidth / 2)
                        {
                            Player.CheckPlayerPos();
                        }
                        else if (tempTouchs.position.x < Camera.main.pixelWidth / 2)
                        {
                            Player.PlayerJump();
                        }

                    }
                    else
                    {
                        return;
                    }
                }
            }
        }


    }*/

        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                return;
            }
            else
            {
                if (tempTouchs.position.x > Camera.main.pixelWidth / 2)
                {
                    Player.CheckPlayerPos();
                }
                else if (tempTouchs.position.x < Camera.main.pixelWidth / 2)
                {
                    Player.PlayerJump();
                }
            }
        }
    }
       
}


