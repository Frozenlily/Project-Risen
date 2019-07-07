using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : ScriptableObject
{
    /*---------------------------------------------------------- Variables ----------------------------------------------------------- */
    public string skillName;
    public Sprite icon;
    public AudioClip sound;
    public float cooldown = 1f;

	/*-------------------------------------------------------- Start/Update ---------------------------------------------------------- */	
	public abstract void Init();

	/*---------------------------------------------------------- Functions ----------------------------------------------------------- */	
    public abstract void OnSkillUse();

}
