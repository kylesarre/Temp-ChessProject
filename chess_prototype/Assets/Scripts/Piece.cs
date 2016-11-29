using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/****************************************************************************************/
/*
/* FILE NAME: Piece
/*
/* DESCRIPTION: A general template for a piece in our chess game (does not get instantiated itself)
 * 
 * AUTHOR: Kyle Sarre
/*
/****************************************************************************************/
public class Piece : MonoBehaviour 
{
	// the cells a piece can currently visit
	protected List<Cell> visitableCells = new List<Cell> ();
	// the direction vectors that indicate alternative ways of moving and capturing another piece
	protected List<Vector3> captureVectors = new List<Vector3> ();
	// all the cells that a piece is threatening at a point in time
	public Dictionary<string, Cell> threatenedCells = new Dictionary<string, Cell>();
	// all of the direction vectors that indicate primary ways of moving and capturing another piece
	protected List<Vector3> movementVectors = new List<Vector3>();
	// the color of the piece
	public bool isWhite;
	// the x index with respect to the board
	protected float currentX;
	// the y index with respect to the board
	protected float currentY;

	// used for initialization
	void Start()
	{
	}

	public virtual void assignMovementVectors() 
	{
	}

	public List<Cell> VisitableCells
	{
		get{return visitableCells;}
		set{visitableCells = new List<Cell>();}
	}

	public List<Vector3> MovementVectors
	{
		get{ return movementVectors;}
	}

	public List<Vector3> CaptureVectors
	{
		get{ return captureVectors;}
	}

	public Dictionary<string, Cell> ThreatenedCells
	{
		get{return threatenedCells;}
	}
	public float CurrentX{ get; set;}
	public float CurrentY{ get; set;}
	public bool IsWhite{ get; set;}
}
