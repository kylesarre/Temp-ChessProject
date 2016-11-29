﻿using UnityEngine;
using System.Collections;
/****************************************************************************************/
/*
/* FILE NAME: Knight
/*
/* DESCRIPTION: A model of the queen piece
 * 
 * AUTHOR: Kyle Sarre
/*
/****************************************************************************************/
public class Queen : Piece 
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
			gameObject.GetComponent<SpriteRenderer> ().sprite = GetComponentInParent<SpriteDictionary> ().SpriteDict["spr_chess_pieces_1"];
		} 
		if(isWhite)
		{
			gameObject.GetComponent<SpriteRenderer> ().sprite	= GetComponentInParent<SpriteDictionary>().SpriteDict["spr_chess_pieces_7"];
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
