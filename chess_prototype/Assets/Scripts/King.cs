using UnityEngine;
using System.Collections;
/****************************************************************************************/
/*
/* FILE NAME: King
/*
/* DESCRIPTION: A model of the most important piece in chess: the king
 * 
 * AUTHOR: Kyle Sarre
/*
/* PARENT CLASS: Piece
/****************************************************************************************/
public class King : Piece 
{
	void Awake()
	{
		Vector3[] vectors = { new Vector3 (1, 1, 0), new Vector3 (-1, 1, 0), new Vector3 (-1, -1, 0), new Vector3 (1, -1, 0),
			new Vector3 (1, 0, 0), new Vector3 (-1, 0, 0), new Vector3 (0, 1, 0), new Vector3 (0, -1, 0) };
		movementVectors.AddRange (vectors);
		enabled = false;
	}
	// Use this for initialization
	void Start () 
	{
		
		if (!isWhite) 
		{			
			gameObject.GetComponent<SpriteRenderer> ().sprite = GetComponentInParent<SpriteDictionary> ().SpriteDict["spr_chess_pieces_5"];
		} 
		if(isWhite)
		{
			gameObject.GetComponent<SpriteRenderer> ().sprite	= GetComponentInParent<SpriteDictionary>().SpriteDict["spr_chess_pieces_11"];
		}
	}
	// Update is called once per frame
	void Update () {
	
	}

	public override void assignMovementVectors()
	{
		captureVectors.Clear ();
		movementVectors.Clear ();
		Vector3[] vectors = { new Vector3 (1, 1, 0), new Vector3 (-1, 1, 0), new Vector3 (-1, -1, 0), new Vector3 (1, -1, 0),
			new Vector3 (1, 0, 0), new Vector3 (-1, 0, 0), new Vector3 (0, 1, 0), new Vector3 (0, -1, 0) };
		movementVectors.AddRange (vectors);
	}
}
