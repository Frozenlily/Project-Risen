using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFall : MonoBehaviour {

	private GameObject obstacle;
	[SerializeField] private float fallSpeed = 10;

	private void Start()
	{
		obstacle = this.gameObject;
	}
	private void Update () 
	{
		obstacle.transform.position = Vector3.Lerp(obstacle.transform.position, obstacle.transform.position - new Vector3(0, 0.1f, 0), fallSpeed *Time.deltaTime);
	}
}
