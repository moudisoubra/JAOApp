using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private bool tap, longTap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDragging = false;
    public bool canTap = false;
    private Vector2 startTouch, swipeDelta, touchDelta;
    public float timer = 0;

    private void Update()
    {
        tap = swipeDown = swipeLeft = swipeRight = swipeUp = false;

        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            canTap = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Reset();
        }

        //---------------------------------Mobile Input----------------------------------------//

        if (Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                Debug.Log("IS DRAGGING");
                isDragging = true;
                canTap = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                swipeDelta = Input.touches[0].position - startTouch;

                Debug.Log("First Touch: " + swipeDelta.magnitude);
                //Reset();
            }

        }

        //--------------------------------Calculate Distance-----------------------------------//
        //swipeDelta = Vector2.zero;

        if (isDragging)
        {
            if (Input.touchCount > 0)
            {
                //swipeDelta = Input.touches[0].position - startTouch;
                //Debug.Log("Touch: " + swipeDelta.magnitude);
            }
            else if(Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        //-------------------------------Swiping if Distance is great enough------------------//
        if (swipeDelta.magnitude < 5 && canTap )
        {
            if (Input.touchCount > 0)
            {
                //Debug.Log("Touch is Running");
                if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
                {
                    tap = true;
                }
                Reset();
            }
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Tap: " + swipeDelta.magnitude);
                tap = true;
                Reset();
            }
        }
        else if (swipeDelta.magnitude > 25)
        {
            Debug.Log("MOVING DIRECTION");
            canTap = false;
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Left or Right
                if (x < 0)
                {
                    swipeLeft = true;
                }
                else
                {
                    swipeRight = true;
                }
            }
            else
            {
                //Up or Down
                if (y < 0)
                {
                    swipeUp = true;
                }
                else
                {
                    swipeDown = true;
                }
            }
            Reset();
        }

    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;
    }
    public Vector2 SwipeDelta {  get { return swipeDelta; } }
    public bool Tap { get { return tap; } }
    public bool LongTap { get { return longTap; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
    public float SwipeDeltas { get { return swipeDelta.magnitude; } }
}
