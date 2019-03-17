using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
	/*---------------------------------------------------------- Variables ----------------------------------------------------------- */
	public float heightFactor = 10.0f;
	/*-------------------------------------------------------- Start/Update ---------------------------------------------------------- */	
	private void Start()
	{
		var baseScale = this.gameObject.transform.localScale;
		var scaleFactor = (heightFactor/100) *(Screen.height);
		this.gameObject.transform.localScale = new Vector3(baseScale.x * scaleFactor, baseScale.y * scaleFactor, 1);
	}

	/*---------------------------------------------------------- Functions ----------------------------------------------------------- */	

}
