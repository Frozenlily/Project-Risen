using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAttack : MonoBehaviour {
	private Collider2D col;
	public float distance = 2.4f;
	
	private void Start()
	{
		col = GetComponent<Collider2D>();
		this.transform.position += Camera.main.ViewportToScreenPoint(new Vector3(0.5f, distance, 0)) + new Vector3(0,0,1);
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		Destroy(this.gameObject);
	}
}
