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
	[SerializeField] private int laneQty; //Number of lanes.
  
	public struct Lane
	{
		public int num;
		public Vector3 pos;
	}
	public Lane[] lanes;
  
	private float laneWidth; //Pixel width of lane.

	/*--------------------------------------------------------- Start/Update --------------------------------------------------------- */
	private void Awake()
	{
		Init();
	}

	/*---------------------------------------------------------- Functions ----------------------------------------------------------- */
	public void Init()
	{
		laneWidth = Camera.main.ViewportToWorldPoint(Vector3.one).x/laneQty;
		Debug.Log (laneWidth + " - Lane Width in World Value");

		lanes = new Lane[laneQty];
    
		//Updates lane details accordingly.
		var i= 0;
		foreach (Lane lane in lanes)
		{
			lanes[i].num = (i+1);
			lanes[i].pos =  ((i)*new Vector3(laneWidth, 0, 0)) + new Vector3(laneWidth, 0, 0)/2;
			i++;
		}
	}
	
	public Vector3 LaneWidth
	{
		get 
		{
			Vector3 a = Vector3.zero;
			Vector3 b = new Vector3(laneWidth, 0, 0);
			return (a + b);
		}
	}
}
