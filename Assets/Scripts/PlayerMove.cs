using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Code leftover and not in use as of 21/10/2020
    //Blake Skinner 08/10/2020 Swipe movement code sourced from https://www.youtube.com/watch?v=jbFYYbu5bdc&feature=emb_title
    //Cant get swiping implemented at present
    private Vector2 FingerDownPosition;
    private Vector2 FingerUpPosition;
    public bool detectSwipeOnlyAfterRelease = false;

    public Transform PlayerLocation;

    private float minDistanceForSwipe = 20f;

    public static event Action<SwipeData> OnSwipe = delegate { };

    public struct SwipeData
    {
        public Vector2 StartPosition;
        public Vector2 EndPosition;
        public SwipeDirection Direction;
    }
    public enum SwipeDirection
    {
        Up,
        Down,
        Left,
        Right
    }


    void Start()
    {
        
    }
    void SwipeDetector_OnSwipe(SwipeData data)
    {
        Debug.Log("This dir" + data.Direction);
    }

        // Update is called once per frame
        void Update()
    {
        
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                FingerUpPosition = touch.position;
                FingerDownPosition = touch.position;
            }

            if (!detectSwipeOnlyAfterRelease && touch.phase == TouchPhase.Moved)
            {
                FingerDownPosition = touch.position;
                DetectSwipe();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                FingerDownPosition = touch.position;
                DetectSwipe();
            }
        }
    }

    void DetectSwipe()
    {
        if (SwipeDistanceCheckMet())
        {
            if (IsVerticalSwipe())
            {
                var direction = FingerDownPosition.y - FingerUpPosition.y > 0 ? SwipeDirection.Up : SwipeDirection.Down;
                SendSwipe(direction);
            }
            else
            {
                var direction = FingerDownPosition.x - FingerUpPosition.x > 0 ? SwipeDirection.Right : SwipeDirection.Left;
                SendSwipe(direction);
            }
            FingerUpPosition = FingerDownPosition;
        }
    }

    private bool IsVerticalSwipe()
    {
        return VerticalMovementDistance() > HorizontalMovementDistance();
    }

    private bool SwipeDistanceCheckMet()
    {
        return VerticalMovementDistance() > minDistanceForSwipe || HorizontalMovementDistance() > minDistanceForSwipe;
    }

    private float VerticalMovementDistance()
    {
        return Mathf.Abs(FingerDownPosition.y - FingerUpPosition.y);
    }

    private float HorizontalMovementDistance()
    {
        return Mathf.Abs(FingerDownPosition.x - FingerUpPosition.x);
    }

    private void SendSwipe(SwipeDirection direction)
    {
        SwipeData swipeData = new SwipeData()
        {
            Direction = direction,
            StartPosition = FingerDownPosition,
            EndPosition = FingerUpPosition
        };
        OnSwipe(swipeData);
    }
}

  
