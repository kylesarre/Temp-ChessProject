﻿using UnityEngine;
using System.Collections;
/****************************************************************************************/
/*
/* FILE NAME: Knight
/*
/* DESCRIPTION: A model of the knight piece
/*
 * AUTHOR: Kyle Sarre
/****************************************************************************************/
public class Knight :  Piece 
{
	void Awake()
	{
		Vector3[] vectors = { new Vector3 (2, 1, 0), new Vector3 (-2, 1, 0), new Vector3 (-2, -1, 0), new Vector3 (2, -1, 0),
			new Vector3 (1, 2, 0), new Vector3 (-1, 2, 0), new Vector3 (-1, -2, 0), new Vector3 (1, -2, 0) };
		movementVectors.AddRange (vectors);
		enabled = false;
	}
	// Use this for initialization
	void Start () 
	{
		if (!isWhite) 
		{			
			gameObject.GetComponent<SpriteRenderer> ().sprite = GetComponentInParent<SpriteDictionary> ().SpriteDict["spr_chess_pieces_4"];
		} 
		if(isWhite)
		{
			gameObject.GetComponent<SpriteRenderer> ().sprite	= GetComponentInParent<SpriteDictionary>().SpriteDict["spr_chess_pieces_10"];
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	public override void assignMovementVectors()
	{
		captureVectors.Clear ();
		movementVectors.Clear ();
		Vector3[] vectors = { new Vector3 (2, 1, 0), new Vector3 (-2, 1, 0), new Vector3 (-2, -1, 0), new Vector3 (2, -1, 0),
			new Vector3 (1, 2, 0), new Vector3 (-1, 2, 0), new Vector3 (-1, -2, 0), new Vector3 (1, -2, 0) };
		movementVectors.AddRange (vectors);
	}
}
