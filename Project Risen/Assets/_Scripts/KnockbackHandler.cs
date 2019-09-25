using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackHandler : MonoBehaviour 
{
    /*---------------------------------------------------------- Variables ----------------------------------------------------------- */
    [SerializeField] private float speed = 5f;
    [SerializeField] private int pushForce = 15;
    private Vector3 pushDistance;
    private Collider2D col;
    
    /*-------------------------------------------------------- Start/Update ---------------------------------------------------------- */
    private void Start()
    {
        pushDistance = new Vector3(0, pushForce * GameUnits.heightFactor, 0);
        col = this.gameObject.GetComponent<Collider2D>();
    }
    /*--------------------------------------------------------- Functions ------------------------------------------------------------ */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            OnKnockbackDetection();
            //Destroy(this.gameObject);
        }
    }
    /*--------------------------------------------------------- Functions ------------------------------------------------------------ */
    public delegate void KnockbackEventHandler(object source, Vector3 pushDistance, float speed);
    public static event KnockbackEventHandler KnockbackDetected;
    
    public virtual void OnKnockbackDetection()
    {
        KnockbackDetected(this, pushDistance, speed);
    }
}