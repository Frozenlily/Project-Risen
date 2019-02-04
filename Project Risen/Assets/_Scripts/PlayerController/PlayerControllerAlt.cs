using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerAlt : MonoBehaviour 
{
    /*--------------------------------------------------------- Variables ------------------------------------------------------------ */
    public Rigidbody2D player;
    public int curLane;
    [SerializeField] private LevelDetailsAlt currentLevel;
    
    /*-------------------------------------------------------- Start/Update ---------------------------------------------------------- */
    private void Start()
    {
        //Event Subscriptions
        InputManager.TouchDetected += OnTouchDetection;
        currentLevel = FindObjectOfType<LevelDetailsAlt>();
        curLane = Mathf.CeilToInt(currentLevel.lanes.Length / 2.0f);
    }
    
    /*--------------------------------------------------------- Functions ------------------------------------------------------------- */
    ///Upon touch detection, get touch input information from input manager.
    public void OnTouchDetection(object source, InputManager.SwipeDirections input)
    {
        PerformAction(input);
    }
    public void OnCollisionStay2D(Collision2D collisionInfo)
    {
        player.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
    }
    public void OnCollisionExit2D(Collision2D collisionInfo)
    {
        player.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    /*--------------------------------------------------------- Functions ------------------------------------------------------------- */
    ///Perform action based on touch input.
    private void PerformAction (InputManager.SwipeDirections direction)
    {
        if (direction == InputManager.SwipeDirections.Tap)
        {
            Debug.Log("Tap");
        }
        if (direction == InputManager.SwipeDirections.Left)
        {
            //Debug.Log("Left");
            //Debug.Log(Screen.width + "; Lane: " + currentLevel.LaneWidth());
            if (curLane >= 1)
            {
                curLane -= 1;
                player.transform.position = new Vector3(currentLevel.lanes[curLane].pos.x, 0 ,0);
            }
        }
        else if (direction == InputManager.SwipeDirections.Right)
        {
            //Debug.Log("Right");
            //Debug.Log(Screen.width + "; Lane: " + currentLevel.LaneWidth());
            if (curLane <= currentLevel.lanes.Length)
            {
                curLane += 1;
                player.transform.position = new Vector3(currentLevel.lanes[curLane].pos.x, 0 ,0);
            }
            
        }
        else if (direction == InputManager.SwipeDirections.Up)
        {
            //Use character skill.
            Debug.Log("Use skill");
        }
        else if (direction == InputManager.SwipeDirections.Down)
        {
            //Use character ultimate arts.
            Debug.Log("Unleashed ultimate arts!");
        }
    }
}
