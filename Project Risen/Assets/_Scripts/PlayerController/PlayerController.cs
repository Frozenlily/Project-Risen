using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    /*--------------------------------------------------------- Variables ------------------------------------------------------------ */
    public Rigidbody2D player;
    [SerializeField] private LevelDetails currentLevel;
    
    /*-------------------------------------------------------- Start/Update ---------------------------------------------------------- */
    private void Start()
    {
        //Event Subscriptions
        InputManager.TouchDetected += OnTouchDetection;
    }
    
    /*--------------------------------------------------------- Functions ------------------------------------------------------------- */
    ///Upon touch detection, get touch input information from input manager.
    public void OnTouchDetection(object source, InputManager.SwipeDirections input)
    {
        PerformAction(input);
    }
    public void OnCollisionStay2D(Collision2D collisionInfo)
    {
        player.constraints = RigidbodyConstraints2D.None;
    }
    public void OnCollisionExit2D(Collision2D collisionInfo)
    {
        player.constraints = RigidbodyConstraints2D.FreezePositionY;
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
            player.transform.Translate(-currentLevel.LaneWidth());
        }
        else if (direction == InputManager.SwipeDirections.Right)
        {
            //Debug.Log("Right");
            //Debug.Log(Screen.width + "; Lane: " + currentLevel.LaneWidth());
            player.transform.Translate(currentLevel.LaneWidth());
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
