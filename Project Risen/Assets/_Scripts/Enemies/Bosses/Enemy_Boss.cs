using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Boss : MonoBehaviour
{
    /*---------------------------------------------------------- Variables ----------------------------------------------------------- */
    private Animator anim;
    public string bossName;
    public string bossDescription;

    //private AlmanacEntry almanacLog;

    #region Health Values
    [SerializeField] private int totalHealth;
    [SerializeField] private int currentHealth;
    public int Health //Use this to get and set boss health.
    {
        get
        {
            return currentHealth;
        }
        set
        {  
            currentHealth = value;
        }
    }
    public float HealthRatio //Use this to get the value of the current boss HP ratio as x%.
    { 
        get
        {
            return ((float)currentHealth/(float)totalHealth) * 100f;
        }
    }
    #endregion
    private List<Attack> Attacks = new List<Attack>();

    /*--------------------------------------------------------- Start/Update --------------------------------------------------------- */
    

    /*---------------------------------------------------------- Functions ----------------------------------------------------------- */


   
    /*------------------------------------------------------------- END -------------------------------------------------------------- */


}
