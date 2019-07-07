using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Risen/Attacks/Conditions/HealthDepend")]
public class HealthDepend : Condition 
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
		base.condType = CondTypes.HealthDepend;
	}
	/*---------------------------------------------------------- Functions ----------------------------------------------------------- */
	///Checks if Condition has been met.
	public override bool IsConditionMet()
	{
		if(addType == AdditionType.Less)
		{
			if (GameObject.FindObjectOfType<Enemy_Boss>().HealthRatio <= threshold)
			{
				return true;
			}
			return false;
		}
		if(addType == AdditionType.More)
		{
			if (GameObject.FindObjectOfType<Enemy_Boss>().HealthRatio >= threshold)
			{
				return true;
			}
			return false;
		}
		if(addType == AdditionType.Equal)
		{
			if (GameObject.FindObjectOfType<Enemy_Boss>().HealthRatio == threshold)
			{
				return true;
			}
			return false;
		}
		return false;
	}
}
