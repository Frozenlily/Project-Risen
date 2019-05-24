using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreatSwing : Attack
{
    [SerializeField] private List<Conditions> conditions = new List<Conditions>();

    public void OnStateEnter()
    {
        if (CheckConditions(conditions))
        {
            //PerformAttack();
        }
    }
    
    public override void PerformAttack(StateMachineBehaviour state)
    {
        
    }
}
