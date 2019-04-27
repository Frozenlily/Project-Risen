using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFall : MonoBehaviour {

	private GameObject obstacle;
	private LevelDetails lvlDetails;
	[SerializeField] private float fallSpeed;

	private void Awake()
	{
		lvlDetails = FindObjectOfType<LevelDetails>();
	}
	private void Start()
	{
		obstacle = this.gameObject;
		fallSpeed *= lvlDetails.HeightFactor; 
	}
	private void FixedUpdate () 
	{
		obstacle.transform.position = Vector3.Lerp(obstacle.transform.position, obstacle.transform.position - new Vector3(0, 1f, 0)*fallSpeed, Time.fixedDeltaTime);
	}
}
