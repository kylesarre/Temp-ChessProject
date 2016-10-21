﻿using UnityEngine;
using System.Collections;

public class Bishop : Piece 
{
	void awake()
	{
		enabled = false;
	}
	// Use this for initialization
	void Start () 
	{
		base.Do_Init();
		Vector3[] vectors = { new Vector3 (1, 1, 0), new Vector3 (-1, 1, 0), new Vector3 (-1, -1, 0), new Vector3 (1, -1, 0) };
		movementVectors.AddRange (vectors);
		if (!isWhite) 
		{			
			gameObject.GetComponent<SpriteRenderer> ().sprite = GetComponentInParent<SpriteDictionary> ().SpriteDict["spr_chess_pieces_3"];
		} 
		if(isWhite)
		{
			gameObject.GetComponent<SpriteRenderer> ().sprite	= GetComponentInParent<SpriteDictionary>().SpriteDict["spr_chess_pieces_9"];
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
