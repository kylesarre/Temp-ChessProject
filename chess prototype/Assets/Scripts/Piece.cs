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
	}

	public void move (Cell cell)
	{
		foreach (Cell validCell in validCells)
		{
			if ( cell.GetInstanceID() == validCell.GetInstanceID() ) 
			{
				this.GetComponent<Transform> ().position = validCell.GetComponent<Transform> ().position;
			}
			return;
		}			
	}
	public List<Cell> ValidCells
	{
		get{return validCells;}
		set{validCells = new List<Cell>();}
	}
	public List<Vector3> MovementVectors
	{
		get{ return movementVectors;}
		set{ movementVectors = new List<Vector3>();}
	}
	public float CurrentX{ get; set;}
	public float CurrentY{ get; set;}
	public bool IsWhite{ get; set;}
}
