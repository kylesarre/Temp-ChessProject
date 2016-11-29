using UnityEngine;
using System.Collections;
/****************************************************************************************/
/*
/* FILE NAME: Cell
/*
/* DESCRIPTION: The base unit of the gameboard. May contain a piece.
 * 
 * AUTHOR: Kyle Sarre
 * 
 * Dependency: component of Grid
/*
/****************************************************************************************/
public class Cell : MonoBehaviour 
{
	public GameObject myPiece;
	private Vector3 cellMidPoint;
	private bool isActive;
	public int row;
	public int column;

	void Awake()
	{
		myPiece = null;
		cellMidPoint = new Vector3(0, 0, 0);
		isActive = true;
	}

	// Use this for initialization
	void Start () 
	{		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void toggleActive()
	{
		isActive = (isActive == true) ? isActive = false : isActive = true;
	}

	public GameObject MyPiece
	{
		get{ return myPiece; }
		set{ myPiece = value; }
	}
	public Vector3 CellMidPoint
	{
		get{ return cellMidPoint;}
		set
		{
			cellMidPoint = value;
		}
	}

//	public Piece GetPiece
//	{
//		get{ return GetComponent<Cell> ().MyPiece.GetComponent<Piece> (); }
//		set{ myPiece = value.gameObject; }
//	}
}