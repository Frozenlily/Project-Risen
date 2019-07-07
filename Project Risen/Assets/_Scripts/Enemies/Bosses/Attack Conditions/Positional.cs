using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Risen/Attacks/Conditions/Positional")]
public class Positional : Condition
{
	/*---------------------------------------------------------- Variables ----------------------------------------------------------- */
	public enum AdditionType
	{
		More,
		Less
	}
	public AdditionType addType = AdditionType.More;
	public float threshold = 0f;
	/*--------------------------------------------------------  Start/Update --------------------------------------------------------- */
	public Positional () : base()
	{
		base.condType = CondTypes.Positional;
	}
	/*---------------------------------------------------------- Functions ----------------------------------------------------------- */
	public override bool IsConditionMet()
	{
		if(addType == AdditionType.Less)
		{
			if (GameObject.FindObjectOfType<PlayerController>().transform.position.y <= threshold * GameUnits.heightFactor)
			{
				return true;
			}
			return false;
		}
		if(addType == AdditionType.More)
		{
			if (GameObject.FindObjectOfType<PlayerController>().transform.position.y >= threshold * GameUnits.heightFactor)
			{
				return true;
			}
			return false;
		}
		return false;
	}

}
