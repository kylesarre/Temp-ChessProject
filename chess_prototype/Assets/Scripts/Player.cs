using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Player : MonoBehaviour 
{
	private string playerName;
	private bool isWhite;
	private Dictionary<string, Cell> myPieces;
	private List<Upgrade> upgrades;
	private bool inCheck;

	// Use this for initialization
	void Start () 
	{
		inCheck = false;
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

	public bool InCheck
	{
		get{ return inCheck;}
		set{ inCheck = value;}
	}
	public Dictionary<string, Cell> MyPieces
	{
		get{return myPieces;}
	}
}
