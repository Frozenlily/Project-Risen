using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : ScriptableObject
{
    /*---------------------------------------------------------- Variables ----------------------------------------------------------- */
    public struct State
    {
        public string sName;
        public List<Condition> conditions;
    }

    public Dictionary<State, Attack> Attacks = new Dictionary<State, Attack>();
    
    public State currentState;
    public State nextState;
    public State[] stateTable;


    /*-------------------------------------------------------- Start/Update ---------------------------------------------------------- */

    /*---------------------------------------------------------- Functions ----------------------------------------------------------- */
    ///Adds a new Dictionary entry based on given values.
    public void AddToDictionary(State stateRef, Attack attackToAdd)
    {
        Attacks.Add(stateRef, attackToAdd);
    }
    ///Removes the specified entry from Dictionary.
    public void RemoveFromDictionary(State stateRef)
    {
        Attacks.Remove(stateRef);
    }

    ///Gets next state to transition to.
    public void GetNextState(State[] state)
    {
        for (int i = 0; i < state.Length; i++)
        {
            if (AllConditionsMet(state[i].conditions))
            {
                nextState = state[i];
                return;
            }
            else
            {
                nextState = currentState;
            }
        }
    }

    ///Checks if all conditions are cleared.
    public bool AllConditionsMet (List<Condition> conditions)
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
}
