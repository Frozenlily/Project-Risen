using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackManager : MonoBehaviour 
{
    /*---------------------------------------------------------- Variables ----------------------------------------------------------- */
    
    /*-------------------------------------------------------- Start/Update ---------------------------------------------------------- */
    private void Start()
    {
        
    }
    private void Update()
    {
        KnockbackDetected();   
    }
    /*--------------------------------------------------------- Functions ------------------------------------------------------------ */
	public delegate void KnockbackEventHandler(object source, Vector3 pushDistance, float time);
	public static event KnockbackEventHandler KnockbackDetected;
    
    public virtual void OnKnockbackDetection()
    {
        OnKnockback(pushDistance);
    }
    
    
}
