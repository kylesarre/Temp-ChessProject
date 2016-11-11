using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Player : MonoBehaviour 
{
	private string playerName;
	private bool isWhite;
	private List<Upgrade> upgrades;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public string PlayerName
	{
		get{return playerName;}
		set{playerName = value;}
	}

	public bool IsWhite
	{
		get{return isWhite;}
		set{isWhite = value;}
	}
}
