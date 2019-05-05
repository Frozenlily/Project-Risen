using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    /*--------------------------------------------------------- Variables ------------------------------------------------------------ */
    public Rigidbody2D player;
    public Character character;
    public int curLane;
    [SerializeField] private LevelDetails currentLevel;
    
    /*-------------------------------------------------------- Start/Update ---------------------------------------------------------- */
    private void Start()
    {
        //Event Subscriptions
        InputManager.TouchDetected += OnTouchDetection;
        currentLevel = FindObjectOfType<LevelDetails>();
        curLane = Mathf.CeilToInt(currentLevel.lanes.Length / 2.0f);
        player.transform.position = new Vector3 (currentLevel.lanes[curLane-1].pos.x, (Screen.height/2) - (player.transform.localScale.y), 1);
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
            Debug.Log("Left");
            //Debug.Log(Screen.width + "; Lane: " + currentLevel.LaneWidth());
            if (curLane > 1)
            {
                StopAllCoroutines();
                curLane--;
                StartCoroutine(Move(currentLevel.lanes[curLane-1].pos));
                //player.transform.position = new Vector3(currentLevel.lanes[curLane-1].pos.x, player.transform.position.y, player.transform.position.z);
            }
        }
        else if (direction == InputManager.SwipeDirections.Right)
        {
            Debug.Log("Right");
            //Debug.Log(Screen.width + "; Lane: " + currentLevel.LaneWidth());
            if (curLane < currentLevel.lanes.Length)
            {
                StopAllCoroutines();
                curLane++;
                StartCoroutine(Move(currentLevel.lanes[curLane-1].pos));
                //player.transform.position = new Vector3(currentLevel.lanes[curLane-1].pos.x, player.transform.position.y, player.transform.position.z);
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

    //Move player towards the destination over a fixed time.
    private IEnumerator Move(Vector3 endPos)
    {
        while (player.transform.position != endPos)
        {
            var movement = new Vector3(endPos.x, player.transform.position.y, player.transform.position.z);
            player.transform.position = Vector3.Lerp(player.transform.position, movement, character.Speed * Time.deltaTime);
            yield return new WaitForSeconds(0.1f*Time.deltaTime);
        }
    }
}
