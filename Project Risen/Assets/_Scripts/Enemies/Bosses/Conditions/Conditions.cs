using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditions : ScriptableObject 
{
	/*---------------------------------------------------------- Variables ----------------------------------------------------------- */
	public enum CondTypes
	{
		None,
		Positional,
		HealthDepend,
		HealthTrigger,
	}
	public CondTypes condType;
	/*--------------------------------------------------------  Start/Update --------------------------------------------------------- */

	/*---------------------------------------------------------- Functions ----------------------------------------------------------- */
	public virtual bool IsConditionMet()
	{
		return false;
	}

}
