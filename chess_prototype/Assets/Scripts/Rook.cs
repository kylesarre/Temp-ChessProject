using UnityEngine;
using System.Collections;
/****************************************************************************************/
/*
/* FILE NAME: Knight
/*
/* DESCRIPTION: A model of the rook piece
 * 
 * AUTHOR: Kyle Sarre
/*
/****************************************************************************************/
public class Rook : Piece 
{
	public RookState state;
	public enum RookState
	{
		NeverMoved, Moved
	}
	void Awake()
	{
		state = RookState.NeverMoved;
		movementVectors.Add (new Vector3 (0, 1, 0));
		movementVectors.Add (new Vector3 (0, -1, 0));
		movementVectors.Add (new Vector3 (1, 0, 0));
		movementVectors.Add (new Vector3 (-1, 0, 0));
		enabled = false;
	}
	// Use this for initialization
	void Start () 
	{
		if (!isWhite) 
		{			
			gameObject.GetComponent<SpriteRenderer> ().sprite = GetComponentInParent<SpriteDictionary> ().SpriteDict["spr_chess_pieces_2"];
		} 
		if(isWhite)
		{
			gameObject.GetComponent<SpriteRenderer> ().sprite	= GetComponentInParent<SpriteDictionary>().SpriteDict["spr_chess_pieces_8"];
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void assignMovementVectors()
	{
		captureVectors.Clear ();
		movementVectors.Clear ();
		movementVectors.Add (new Vector3 (0, 1, 0));
		movementVectors.Add (new Vector3 (0, -1, 0));
		movementVectors.Add (new Vector3 (1, 0, 0));
		movementVectors.Add (new Vector3 (-1, 0, 0));
	}
}
