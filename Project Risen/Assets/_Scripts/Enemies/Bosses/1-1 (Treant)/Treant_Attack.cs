using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treant_Attack : MonoBehaviour 
{
	/*--------------------------------------------------------- Variables ------------------------------------------------------------ */
	private Animator animator;
	private float GU = GameUnits.heightFactor;

	/*-------------------------------------------------------- Start/Update ---------------------------------------------------------- */
	private void Init()
	{

	}
	
	private void Start()
	{

	}

	/*---------------------------------------------------------- Functions ----------------------------------------------------------- */
	//Contains info on attack patterns
	private void AttackPattern()
	{
		/* START
		Attack 1: Great Swing (Melee)
			Condition: Player.Pos > 40% (Screen)
				if (Player.pos.y > 40(GU)) //Only if player positon > 40% of screen height

			Targeting: AoE (3 Lanes) | Center on Player

			Damage: 25% (Instant)
				OnCollisionEnter()
				{
					if (col.other.gameObject.tag == "player") //If object is player (use tags?)
					{
						col.other += event.AddKnockback (25(GU), 0.15s Actual Time); //Calls knockback function. Player should be subscribed to on hit events?
					}
				}

			Speed: 1.5s (Charge Up) | 1.5s (Swing)
				Play (ChargeUpAnimation)
				Display Warning Indicators in Targeted Lanes
				
				WaitForChargeAnimation

				Play (Swing Animation)
				Move Hitbox across TargetLanes Over 1.5s
					Hitbox.StartL = Target.StartLane;
					Hitbox.MoveTowards(EndLane, 1.5s);
				Swing Animation 1.5s
		
		END */

		/* START
		Attack 2: Apple Throw (Projectile)
			Condition: None

			Targeting: Aimed

			Damage: 5% (Instant)

			Speed: 0.5s (Charge Up) | 0.5s (Swing) | 50 GU/s


		END */

	}

}
