using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ScriptableObject
{
    /*--------------------------------------------------------- Variables ------------------------------------------------------------ */
    [SerializeField] private int id;
    [SerializeField] private string name;
    [SerializeField] private int speed;
    
    public int id 
    {
        get
        {
            return id;
        }
    }
    
    public string name
    {
        get
        {
            return name;
        }
    }
    
    /*-------------------------------------------------------- Start/Update ---------------------------------------------------------- */
     
    /*--------------------------------------------------------- Functions ------------------------------------------------------------- */

    /*--------------------------------------------------------- Functions ------------------------------------------------------------- */
    ///Perform action based on touch input.

}
