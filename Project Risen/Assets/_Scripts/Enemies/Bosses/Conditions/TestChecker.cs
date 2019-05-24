using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChecker : MonoBehaviour {

	public Conditions conditionToCheck;

	private void Start()
	{
		if (conditionToCheck.IsConditionMet())
		{
			Debug.Log("Player Threshold " + true);
		}
		else
		{
			Debug.Log("Player Threshold "+ false);
		}
	}

	private void Update()
	{
		if (conditionToCheck.IsConditionMet())
		{
			Debug.Log("Has hit threshold.");
			Debug.Log("Game Over");
			Destroy(GameObject.FindObjectOfType<PlayerController>().gameObject);
			Time.timeScale = 0f;
			Destroy(this.gameObject);
		}
	}
}
