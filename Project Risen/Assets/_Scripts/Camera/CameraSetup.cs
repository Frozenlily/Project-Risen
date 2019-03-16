using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraSetup : MonoBehaviour 
{
	/*---------------------------------------------------------- Variables ----------------------------------------------------------- */

	/*-------------------------------------------------------- Start/Update ---------------------------------------------------------- */	
	private void Start()
	{
		Camera.main.orthographicSize = Screen.height/2.0f;
		Camera.main.transform.position = new Vector3 (Screen.width/2.0f, Screen.height/2.0f, 0);
	}


	/*---------------------------------------------------------- Functions ----------------------------------------------------------- */
}
