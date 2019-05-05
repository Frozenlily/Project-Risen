using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUnits : MonoBehaviour 
{
	/*--------------------------------------------------------- Variables ------------------------------------------------------------ */
	///The default Game Unit used in all calculations. 1 GU = 1% of the Screen Height
	public static float heightFactor;
	/*-------------------------------------------------------- Start/Update ---------------------------------------------------------- */
	//Sets GU value in terms of WorldPoint. So you don't have to calculate that messy shit.
	private void Init()
	{
		heightFactor = Camera.main.ViewportToWorldPoint(Vector3.one).y/100;
	}
	private void Awake()
	{
		Init();
	}

}
