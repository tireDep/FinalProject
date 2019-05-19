using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{   
    public enum SwipeDirection
    {
        None = 0, Left = 1, Right = 2, Up = 4, Down = 8
    }

    private static SwipeManager m_instance;

    public static SwipeManager Instance
    {
        get
        {
            if (!m_instance)
            {
                m_instance = new GameObject("SwipeManager").AddComponent<SwipeManager>();
            }

            return m_instance;
        }
    }


    public SwipeDirection Direction { get; private set; }

    private Vector3 m_touchPosition;
    private float m_swipeResistanceX = 50.0f;
    private float m_swipeResistanceY = 100f;

    private void Start()
    {
        if (m_instance != this)
        {
            Debug.LogError("Don't instantiate SwipeManager manually");
            DestroyImmediate(this);
        }
    }

    private void Update()
    {
        
        Direction = SwipeDirection.None;

        if (Input.GetMouseButtonDown(0))
        {
            m_touchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 deltaSwipe = m_touchPosition - Input.mousePosition;

            if (Mathf.Abs(deltaSwipe.x) > m_swipeResistanceX)
            {
                // Swipe on the X axis
                Direction |= (deltaSwipe.x < 0) ? SwipeDirection.Right : SwipeDirection.Left;
            }

            if (Mathf.Abs(deltaSwipe.y) > m_swipeResistanceY)
            {
                // Swipe on the Y axis
                Direction |= (deltaSwipe.y < 0) ? SwipeDirection.Up : SwipeDirection.Down;
            }
        }
    }

    public bool IsSwiping(SwipeDirection dir)
    {
        return (Direction & dir) == dir;
    }

}
