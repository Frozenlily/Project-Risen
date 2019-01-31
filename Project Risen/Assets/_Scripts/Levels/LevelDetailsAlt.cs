using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDetailsAlt : MonoBehaviour 
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
  
	public struct Lane
	{
		public int num;
		public Vector3 pos;
	}
	public Lane[] lanes;
  
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
		laneWidth = Screen.width/laneQty;
		heightFactor = Screen.height/100;
		
		lanes = new Lane[laneQty]
    
		//Updates lane details accordingly.
		var i= 1;
		foreach (Lane lane in lanes)
		{
			lane.num = i;
			lane.pos = i*LaneWidth/2;
			i++
		}
	}
	
	public Vector3 LaneWidth
	{
		get 
		{
			Vector3 a = Camera.main.ScreenToWorldPoint(Vector3.zero);
			Vector3 b = Camera.main.ScreenToWorldPoint(new Vector3(laneWidth, 0, 0));
			return (a + b);
		}
	}
	public Vector3 HeightFactor
	{
		get
		{
			return Camera.main.ScreenToWorldPoint(new Vector3(0, heightFactor, 0));
		}
	}
}
