using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Risen/Attacks/Conditions/HealthTrigger")]
public class HealthTrigger : Condition
{
	/*---------------------------------------------------------- Variables ----------------------------------------------------------- */
	[SerializeField] private float threshold = 0f;
	[SerializeField] private bool hasTriggered = false;
	/*--------------------------------------------------------  Start/Update --------------------------------------------------------- */
	public HealthTrigger () : base()
	{
		base.condType = CondTypes.HealthTrigger;
	}
	public void OnEnable() //Reset the trigger.
	{
		hasTriggered = false;
	}
	/*---------------------------------------------------------- Functions ----------------------------------------------------------- */
	public override bool IsConditionMet()
	{
		if (FindObjectOfType<Enemy_Boss>().HealthRatio <= threshold && !hasTriggered)
		{
			Debug.Log("returned true");
			hasTriggered = true;
			return true;
		}
		return false;
	}
}
