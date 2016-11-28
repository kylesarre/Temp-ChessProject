using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Grid : MonoBehaviour 
{
	public int numOfColumns;
	public int numOfRows;
	public float distanceBetweenTiles;
	public GameObject[,] grid;


	void Awake()
	{
		numOfColumns = 8;
		numOfRows = 8;
		distanceBetweenTiles = 1f;
		grid = new GameObject[numOfColumns, numOfRows];
	}
	// Use this for initialization
	void Start () 
	{
	}

	// Update is called once per frame
	void Update () 
	{
		
	}
	// instantiates all of the cells for our board and places the pieces in their initial positions

	public int NumOfColumns
	{
		get { return numOfColumns; }
	}
	public int NumOfRows
	{
		get { return numOfRows; }
	}
	public float Spacing
	{
		get{ return distanceBetweenTiles;}
	}
}
