using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    /*--------------------------------------------------------- Variables ------------------------------------------------------------ */
    public Rigidbody2D player;
    public Character character;
    public Animator charAnim;
    public int curLane;
    [SerializeField] private LevelDetails currentLevel;
    
    //Coroutines
    Coroutine move;
    private bool isMoving = false;
    private bool isKnockback = false;
    private bool isInvincible = false;
    [SerializeField] private float dValue = 0.5f; //Displacement Value for snapping player position. Higher values lead to more visual discrepancies.

    /*-------------------------------------------------------- Start/Update ---------------------------------------------------------- */
    private void Start()
    {
        //Event Subscriptions
        InputManager.TouchDetected += OnTouchDetection;
        KnockbackManager.KnockbackDetected += OnKnockbackDetection;
 
        currentLevel = FindObjectOfType<LevelDetails>();
        curLane = Mathf.CeilToInt(currentLevel.lanes.Length / 2.0f);
        ResetPosition();
    }
    ///Resets player position to center of screen.
    public void ResetPosition()
    {
        var xPos = currentLevel.lanes[curLane-1].pos.x;
        player.transform.position = new Vector3 (xPos, GameUnits.heightFactor* 50 - (player.transform.localScale.y), 1);
    }
    
    /*--------------------------------------------------------- Functions ------------------------------------------------------------ */
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
    ///Upon Knockback Detected, get knockback information from attacker.
    public void OnKnockbackDetection(object source, Vector3 pushDistance, float speed)
    {
        if (!isInvincible && !isKnockback)
        {
            StartCoroutine(Knockback(pushDistance, speed));
        }
    }
    /*--------------------------------------------------------- Functions ------------------------------------------------------------ */
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
                if (!isKnockback)
                {  
                    StopAllCoroutines();
                    curLane--;
                    StartCoroutine(Move(currentLevel.lanes[curLane-1].pos));
                }
                //player.transform.position = new Vector3(currentLevel.lanes[curLane-1].pos.x, player.transform.position.y, player.transform.position.z);
            }
        }
        else if (direction == InputManager.SwipeDirections.Right)
        {
            Debug.Log("Right");
            //Debug.Log(Screen.width + "; Lane: " + currentLevel.LaneWidth());
            if (curLane < currentLevel.lanes.Length)
            {
                if (!isKnockback)
                {  
                    StopAllCoroutines();
                    curLane++;
                    StartCoroutine(Move(currentLevel.lanes[curLane-1].pos));
                }
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
    ///Move player towards the destination over a fixed time.
    private IEnumerator Move(Vector3 endPos)
    {
        isMoving = true;
        while (player.transform.position.x != endPos.x)
        {
            var movement = new Vector3(endPos.x, player.transform.position.y, player.transform.position.z);
            player.transform.position = Vector3.Lerp(player.transform.position, movement, character.Speed * Time.deltaTime);

            //Snaps player to end position if close enough.
            if (Vector3.Distance(player.transform.position, endPos) < dValue * GameUnits.heightFactor)
            {
                player.transform.position = endPos;
            }
            yield return new WaitForSeconds(0.1f*Time.deltaTime);
        }
        isMoving = false;
    }
    ///Moves player down with a variable speed upon knockback.
    private IEnumerator Knockback(Vector3 pushDistance, float speed)
    {
        if(!isInvincible)
        {
            StartCoroutine(I_Frames(0.5f));
        }
        isKnockback = true;
        var endPos = player.transform.position - pushDistance;
        
        //Debug.Log("Knockback");
        while (player.transform.position.y != endPos.y && isInvincible)
        {
            var movement = new Vector3(player.transform.position.x, endPos.y, player.transform.position.z);
            player.transform.position = Vector3.Lerp(player.transform.position, movement, speed * Time.deltaTime);

            //Snaps player to end position if close enough.
            if (Vector3.Distance(player.transform.position, endPos) < dValue * GameUnits.heightFactor)
            {
                player.transform.position = endPos;
            }
            yield return new WaitForSeconds(0.1f*Time.deltaTime);
        }
        isKnockback = false;
        
        yield break;
    }
    ///Creates I_Frame period based on time given.
    private IEnumerator I_Frames(float time)
    {
        player.gameObject.GetComponent<Collider2D>().enabled = false;
        isInvincible = true;

        yield return new WaitForSeconds(time);

        player.gameObject.GetComponent<Collider2D>().enabled = true;
        isInvincible = false;

        yield break;
    }
}
