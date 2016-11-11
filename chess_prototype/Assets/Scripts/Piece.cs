using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Piece : MonoBehaviour 
{
	protected List<Cell> validCells;
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
		validCells = new List<Cell> ();
	}
		
	public List<Cell> ValidCells
	{
		get{return validCells;}
		set{validCells = new List<Cell>();}
	}
	public List<Vector3> MovementVectors
	{
		get{ return movementVectors;}
	}
	public float CurrentX{ get; set;}
	public float CurrentY{ get; set;}
	public bool IsWhite{ get; set;}
}
