using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Risen/Character")]
public class Character : ScriptableObject
{
    /*--------------------------------------------------------- Variables ------------------------------------------------------------ */
    [SerializeField] private int id;
    [SerializeField] private string pName;
    [SerializeField] [Range(1,5)] private int speed = 3;
    
    public int ID 
    {
        get
        {
            return id;
        }
    }
    
    public string Name
    {
        get
        {
            return pName;
        }
    }
    public int Speed
    {
        get
        {
            return speed;
        }
        set
        {
            value = Mathf.Clamp(speed, 1, 5);
        }
    }
    
    /*-------------------------------------------------------- Start/Update ---------------------------------------------------------- */

    /*--------------------------------------------------------- Functions ------------------------------------------------------------- */

    /*--------------------------------------------------------- Functions ------------------------------------------------------------- */
    ///Perform action based on touch input.

}
