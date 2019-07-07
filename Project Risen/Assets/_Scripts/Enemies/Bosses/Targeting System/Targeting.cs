using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : ScriptableObject
{
	/*---------------------------------------------------------- Variables ----------------------------------------------------------- */
    public enum TargetTypes
    {
        Random,
        Aimed,
        AimedAoE,
        AimedLane,
        AoE,
        Lane,
        Unavoidable
    }
    [SerializeField] private TargetTypes targetType;
    /*--------------------------------------------------------  Start/Update --------------------------------------------------------- */
	/*---------------------------------------------------------- Functions ----------------------------------------------------------- */
    public void targeting()
    {
        
    }
}
