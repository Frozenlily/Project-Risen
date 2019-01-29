using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDetails : MonoBehaviour 
{
	/*---------------------------------------------------------- Variables ----------------------------------------------------------- */
	public enum LevelTypes
	{
		Normal,
		Chase,
		Boss
	}
	[SerializeField] private LevelTypes levelType;
	[SerializeField] private float levelTime;
	[SerializeField] private float laneQty; //Number of lanes.
	private float laneWidth; //Pixel width of lane.
	private float heightFactor; //Unit of measurement; 0 - Bottom of Screen; 100 - Top of Screen. (Used for damage calculations)

	/*--------------------------------------------------------- Start/Update --------------------------------------------------------- */
	private void Awake()
	{
		Init();
	}

	/*---------------------------------------------------------- Functions ----------------------------------------------------------- */
	public void Init()
	{
		Camera camm = FindObjectOfType<Camera>();
		laneWidth = Screen.width/laneQty;
		heightFactor = Screen.height/100;
	}
    public Vector3 LaneWidth()
    {
        Vector3 a = Camera.main.ScreenToWorldPoint(Vector3.zero);
        Vector3 b = Camera.main.ScreenToWorldPoint(new Vector3(laneWidth, 0, 0));
        return (a - b);
    }
}
