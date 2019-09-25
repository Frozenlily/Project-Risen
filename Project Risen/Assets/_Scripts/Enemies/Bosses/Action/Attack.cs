using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : ScriptableObject
{
    /*---------------------------------------------------------- Functions ----------------------------------------------------------- */
    ///Runs the code to perform the attack here.
    public virtual void PerformAttack ()
    {
        //Does something.
    }

    ///Checks all conditional modifiers.
    public bool CheckConditions (List<Condition> conditions)
    {
        var i = 0; //Index
        foreach (Condition condition in conditions) //Checks if all conditions met.
        {
            if (condition.IsConditionMet())
            {
                i++;
            }
        }
        
        if (i == conditions.Count) //If all met.
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    ///Determines which targeting rules to follow.
    public virtual void Targeting()
    {

    }

    /*------------------------------------------------------------- END -------------------------------------------------------------- */
}
