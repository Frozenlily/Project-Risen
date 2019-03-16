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
		this.gameObject.transform.localScale*= (heightFactor/100) *(Screen.height);
	}

	/*---------------------------------------------------------- Functions ----------------------------------------------------------- */	

}
