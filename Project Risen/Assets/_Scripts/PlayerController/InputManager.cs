using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour 
{
    /*---------------------------------------------------------- Variables ----------------------------------------------------------- */
    [SerializeField] private float minSwipe = 12f;
	private Vector3 sp, ep; //Start Point and End Point of input.
	private float minDistance; //Min distance required for swipes to be registered.
	private static bool isSwipe; //Checks if input is swipe based on distance covered by action.

    /*-------------------------------------------------------- Start/Update ---------------------------------------------------------- */
    private void Start()
    {
        minDistance = Screen.height * (Mathf.Clamp(minSwipe, 5f, 20f) / 100f);
        Debug.Log(minDistance);
    }
    private void Update()
    {
        TouchDetection();   
    }
    /*--------------------------------------------------------- Functions ------------------------------------------------------------- */
	public delegate void TouchDetectionEventHandler(object source, SwipeDirections input);
	public static event TouchDetectionEventHandler TouchDetected;

	protected virtual void OnTouchDetected()
	{
		if (TouchDetected != null)
		{
			TouchDetected(this, GetSwipeDirection());
		}
	}

    private void TouchDetection() 
    {
        //Swipe or tap.
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);  

            if (touch.phase == TouchPhase.Began)
            {
                sp = touch.position;
                ep = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                ep = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                ep = touch.position;
                
                //Swipe detected.
                if (Mathf.Abs(sp.x - ep.x) > minDistance || Mathf.Abs(sp.y - ep.y) > minDistance)
                {
					isSwipe = true;
					OnTouchDetected();
                }
                //Touch detected.
                else
                {
					isSwipe = false;
					OnTouchDetected();
                }
            }
        }
    }

    public enum SwipeDirections{Up, Down, Left, Right, Tap}
    private SwipeDirections GetSwipeDirection()
    {
		if (isSwipe)
		{
			//Horizontal Movement
			if (Mathf.Abs(sp.x - ep.x) > Mathf.Abs(sp.y - ep.y))
			{
				if (ep.x > sp.x)
				{
					return SwipeDirections.Right;
				}
				else
				{
					return SwipeDirections.Left;
				}
			}
			//Vertical Movement
			else
			{
				if (ep.y > sp.y)
				{
					return SwipeDirections.Up;
				}
				else
				{
					return SwipeDirections.Down;
				}
			}
		}
		else
		{
			return SwipeDirections.Tap;
		}
	}
}
