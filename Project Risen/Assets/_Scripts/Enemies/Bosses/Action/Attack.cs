using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : StateMachineBehaviour
{
    /*---------------------------------------------------------- Functions ----------------------------------------------------------- */
    ///Runs the code to perform the attack here.
    public virtual void PerformAttack (StateMachineBehaviour state)
    {
        //Does something.
    }

    ///Checks all conditional modifiers.
    public bool CheckConditions (List<Conditions> conditions)
    {
        var i = 0; //Index
        foreach (Conditions condition in conditions) //Checks if all conditions met.
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
    public void Targeting()
    {

    }

    /*------------------------------------------------------------- END -------------------------------------------------------------- */
}
