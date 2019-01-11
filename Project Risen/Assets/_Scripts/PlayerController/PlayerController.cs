using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    /*--------------------------------------------------------- Variables ------------------------------------------------------------ */
    public Rigidbody2D player;
    
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
    
    ///Perform action based on touch input.
    private void PerformAction (InputManager.SwipeDirections direction)
    {
        if (direction == InputManager.SwipeDirections.Tap)
        {
            Debug.Log("Tap");
        }
        if (direction == InputManager.SwipeDirections.Left)
        {
            Debug.Log("Left");
            player.AddForce(Vector3.left * 50f);
        }
        else if (direction == InputManager.SwipeDirections.Right)
        {
            Debug.Log("Right");
            player.AddForce(Vector3.right * 50f);
        }
        else if (direction == InputManager.SwipeDirections.Up)
        {
            //Use character skill.
            Debug.Log("Use skill");
        }
    }
}
