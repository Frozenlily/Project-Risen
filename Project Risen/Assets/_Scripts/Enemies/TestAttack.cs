using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAttack : MonoBehaviour {
	private Collider2D col;
	
	private void Start()
	{
		col = GetComponent<Collider2D>();
		this.transform.position = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 2.4f, 0)) + new Vector3(0,0,1);
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		other.gameObject.transform.position -= new Vector3(0, GameUnits.heightFactor, 0) * 15f;
		Destroy(this.gameObject);
	}
}
