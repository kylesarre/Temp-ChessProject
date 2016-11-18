using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Piece : MonoBehaviour 
{
	protected List<Cell> visitableCells;
	protected Dictionary<string, Cell> threatenedCells;
	protected List<Vector3> movementVectors;
	public bool isWhite;
	protected float currentX;
	protected float currentY;

	void start()
	{
		Do_Init ();
	}
	public void Do_Init()
	{
		movementVectors = new List<Vector3>();
		visitableCells = new List<Cell> ();
		threatenedCells = new Dictionary<string, Cell>();
	}
		
	public List<Cell> ValidCells
	{
		get{return visitableCells;}
		set{visitableCells = new List<Cell>();}
	}
	public List<Vector3> MovementVectors
	{
		get{ return movementVectors;}
	}
	public Dictionary<string, Cell> ThreatenedCells
	{
		get{return threatenedCells;}
	}
	public float CurrentX{ get; set;}
	public float CurrentY{ get; set;}
	public bool IsWhite{ get; set;}
}
