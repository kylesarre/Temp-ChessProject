using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Piece : MonoBehaviour 
{
	protected List<Cell> visitableCells = new List<Cell> ();
	public Dictionary<string, Cell> threatenedCells = new Dictionary<string, Cell>();
	protected List<Vector3> movementVectors = new List<Vector3>();
	public bool isWhite;
	protected float currentX;
	protected float currentY;

	void Awake()
	{
		
	}
	void Start()
	{
	}
	public void Do_Init()
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
	public Dictionary<string, Cell> ThreatenedCells
	{
		get{return threatenedCells;}
	}
	public float CurrentX{ get; set;}
	public float CurrentY{ get; set;}
	public bool IsWhite{ get; set;}
}
