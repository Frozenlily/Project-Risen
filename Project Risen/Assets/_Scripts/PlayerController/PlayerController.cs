using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    /*--------------------------------------------------------- Variables ------------------------------------------------------------ */
    public Rigidbody2D player;
    
    /*-------------------------------------------------------- Start/Update ---------------------------------------------------------- */
    private void Start()
    {
        InputManager.TouchDetected += OnTouchDetection;
    }
    private void Update()
    {

    }
    public void OnTouchDetection(object source, InputManager.SwipeDirections input)
    {
        PerformAction(input);
    }

    /*--------------------------------------------------------- Functions ------------------------------------------------------------- */
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
