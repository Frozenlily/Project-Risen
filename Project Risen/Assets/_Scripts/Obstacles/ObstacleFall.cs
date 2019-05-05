using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFall : MonoBehaviour {

	private GameObject obstacle;
	[SerializeField] private float fallSpeed;
	private void Start()
	{
		obstacle = this.gameObject;
		fallSpeed *= GameUnits.heightFactor;
	}
	private void FixedUpdate () 
	{
		obstacle.transform.position = Vector3.Lerp(obstacle.transform.position, obstacle.transform.position - new Vector3(0, 1f, 0)*fallSpeed, Time.fixedDeltaTime);
	}
}
