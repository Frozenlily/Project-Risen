using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFall : MonoBehaviour {

	public Rigidbody2D obstacle;
	public float fallSpeed = 10;

	private void Start()
	{
		obstacle = GetComponent<Rigidbody2D>();
	}
	private void Update () 
	{
		obstacle.transform.position = Vector3.Lerp(obstacle.transform.position, obstacle.transform.position - new Vector3(0, 0.1f, 0), fallSpeed *Time.deltaTime);
	}
}
