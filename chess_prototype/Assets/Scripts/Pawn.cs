﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Pawn : Piece
{
	
	public bool hasMoved;
	public List<Vector3> captureVectors;

	// awake occurs before start
	void Awake()
	{
        captureVectors = new List<Vector3>();		
		hasMoved = false;
		// ensures that we can set this Piece's isWhite field before trying to access it Do_Init()
		enabled = false;
        // initialize data structures defined in parent class
        base.Do_Init();       
    }
	// Use this for initialization
	void Start () 
	{
        
        // assign the correct sprite to this pawn
        if (!isWhite)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = GetComponentInParent<SpriteDictionary>().SpriteDict["spr_chess_pieces_0"];
        }
        else
        {
            // assign the correct sprite to this pawn
            gameObject.GetComponent<SpriteRenderer>().sprite = GetComponentInParent<SpriteDictionary>().SpriteDict["spr_chess_pieces_6"];
        }
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}		

    public void assignMovementVectors()
    {
        if(!isWhite)
        {
            // a pawn ca move in the forward direction
            movementVectors.Add(new Vector3(0, 1, 0));
            // a pawn can capture diagonally to the right
            captureVectors.Add(new Vector3(1, 1, 0));
            // a pawn can capture diagonally to the left
            captureVectors.Add(new Vector3(-1, 1, 0));
        }
        else
        {
            // a pawn can move in the forward direction
            movementVectors.Add(new Vector3(0, -1, 0));
            // a pawn can capture diagonally to the right
            captureVectors.Add(new Vector3(1, -1, 0));
            // a pawn can capture diagonally to the left
            captureVectors.Add(new Vector3(-1, -1, 0));
        }
    }
}
