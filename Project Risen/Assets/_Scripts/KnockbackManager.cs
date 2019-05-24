using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackManager : MonoBehaviour 
{
    /*---------------------------------------------------------- Variables ----------------------------------------------------------- */
    [SerializeField] private float speed = 15;
    [SerializeField] private int pushforce = 15;
    private Vector3 pushDistance;
    private Collider2D col;
    
    /*-------------------------------------------------------- Start/Update ---------------------------------------------------------- */
    private void Start()
    {
        pushDistance = new Vector3(0, pushForce * GameUnits.heightFactor, 0);
        col = gameObject.GetComponent<Collider2D>();
    }
    private void Update()
    {
        KnockbackDetected();   
    }
    /*--------------------------------------------------------- Functions ------------------------------------------------------------ */
    private void OnTriggerEnter(Collider2D other)
    {
        if(other.tag == "Player")
        {
            OnKnockbackDetection();
        }
    }
    /*--------------------------------------------------------- Functions ------------------------------------------------------------ */
    public delegate void KnockbackEventHandler(object source, Vector3 pushDistance, float speed);
    public static event KnockbackEventHandler KnockbackDetected;
    
    public virtual void OnKnockbackDetection()
    {
        KnockbackDetected(pushDistance, speed);
    }
}
