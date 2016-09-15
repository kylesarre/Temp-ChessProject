using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Pawn : Piece
{
	public PawnState currentState;
	public enum PawnState
	{
		NeverMoved, Moved
	}
	// awake occurs before start
	void Awake()
	{		
		currentState = PawnState.NeverMoved;
		// ensures that we can set this Piece's isWhite field before trying to access it Do_Init()
		enabled = false;
	}
	// Use this for initialization
	void Start () 
	{
		
		//Debug.Log (IsWhite);
		base.Do_Init();
		Debug.Log (isWhite);
		if (!isWhite) 
		{
			Debug.Log ("Inside the black block");
			movementVectors.Add (new Vector3 (1, 0, 0));
			gameObject.GetComponent<SpriteRenderer> ().sprite = sprBlack;
		} 
		if(isWhite)
		{
			Debug.Log ("Inside the white block");
			movementVectors.Add (new Vector3 (-1, 0, 0));
			gameObject.GetComponent<SpriteRenderer> ().sprite = sprWhite;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}		

}
