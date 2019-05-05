using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDepend : Conditions 
{
	/*---------------------------------------------------------- Variables ----------------------------------------------------------- */
	public enum AdditionType
	{
		More,
		Less,
		Equal
	}
	public AdditionType addType = AdditionType.More;
	public float threshold = 0f;
	/*--------------------------------------------------------  Start/Update --------------------------------------------------------- */
	public HealthDepend () : base()
	{
		base.condType = CondTypes.Positional;
	}
	/*---------------------------------------------------------- Functions ----------------------------------------------------------- */
	///Checks if Condition has been met.
	public override bool IsConditionMet()
	{
		/* START

		if(addType == AdditionType.Less)
		{
			if (GameObject.FindObjectOfType<Boss>().Health <= threshold)
			{
				return true;
			}
			return false;
		}
		if(addType == AdditionType.More)
		{
			if (GameObject.FindObjectOfType<Boss>().Health >= threshold)
			{
				return true;
			}
			return false;
		}
		if(addType == AdditionType.Equal)
		{
			if (GameObject.FindObjectOfType<Boss>().Health == threshold)
			{
				return true;
			}
			return false;
		}
		END */
		return false;
	}
}
