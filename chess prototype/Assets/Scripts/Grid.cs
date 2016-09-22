using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Grid : MonoBehaviour 
{
    public GameObject tilePrefab;
	public int numOfColumns;
	public int numOfRows;
	public int numOfCells;
	public int currCells;
	public static float distanceBetweenTiles;
	public GameObject[,] grid;
	public List<GameObject> chessPiecePrefab;
	public List<GameObject> activeChessPiece;

	private int selectionX;
	private int selectionY;

	// Use this for initialization
	void Start () 
	{
		numOfColumns = 8;
		numOfRows = 8;
		numOfCells = numOfColumns*numOfRows;
		distanceBetweenTiles = 1f;
		grid = new GameObject[numOfColumns, numOfRows];
		selectionX = -1;
		selectionY = -1;
		createBoard ();
	}

	// Update is called once per frame
	void Update () 
	{
		UpdateSelection ();
		drawSelected ();
	}
	// retrieves the x and y coordinates of the cell object the mouse is currently hovering over and stores it
	private void UpdateSelection()
	{
		if (!Camera.main) 
		{
			Debug.Log ("No main camera, exiting.");
			return;
		}
		RaycastHit2D hit;
		hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero, LayerMask.GetMask("bottom"));
		if (hit) {
			Debug.Log (hit.point);
			selectionX = Mathf.FloorToInt(hit.point.x);
			selectionY = Mathf.FloorToInt(hit.point.y);

		} 
		else 
		{
			selectionX = -1;
			selectionY = -1;
		}
	}
	// instantiates the specified chess piece prefab at the specified location
	// indexes: 0 [Pawn], 1[rook], 2[knight], 3[Bishop], 4[Queen], 5[King]
	// location: the cell where the Piece resides
	// isWhite: true whenever the piece is for player White, false when the piece is for player Black
	private void InstantiateChessPiece(int index, GameObject cell, int i, int j, bool isWhite)
	{
		// we want the piece to spawn at the center of its specified cell, so we call this function and store the data
		Vector3 centeredPos = getCellCenter (cell);
		GameObject newPiece = (GameObject)Instantiate (chessPiecePrefab[index], centeredPos, Quaternion.identity);
		newPiece.transform.parent = cell.transform;
		cell.GetComponent<Cell>().MyPiece = newPiece; 

		// now we can set all the fields of our Piece
		if(newPiece.GetComponent<Piece>() != null)
		{
			Piece pieceScript = cell.GetComponent<Cell> ().MyPiece.GetComponent<Piece> ();
			pieceScript.isWhite = isWhite;
			pieceScript.CurrentX = centeredPos.x;
			pieceScript.CurrentY = centeredPos.y;
			pieceScript.enabled = true;
		}
		else
		{
			Debug.LogError("Error: the prefab at chessPiecePrefab["+index+"] does not contain a Piece script. Objects in this collection must have a Piece component.");
		}
	}
	private Vector3 getCellCenter(GameObject cell)
	{
		Vector3 cellOrigin = cell.GetComponent<Transform> ().position;
		Vector3 cellEndPoint = new Vector3 (cellOrigin.x + distanceBetweenTiles, cellOrigin.y + distanceBetweenTiles, 0);
		Vector3 cellCenterPos = new Vector3( (cellOrigin.x + cellEndPoint.x) / 2, (cellOrigin.y + cellEndPoint.y) / 2, 0);
		return cellCenterPos;
	}
	// instantiates all of the cells for our board and places the pieces in their initial positions
	private void createBoard()
	{		
		int i,j;
		float xOffset, yOffset;
		xOffset = yOffset = 0.00f;
		for (i = 0; i < numOfRows; i++) 
		{
			for (j = 0; j < numOfColumns; j++) 
			{
				// instantiate board cells, assign associated sprite
				grid [i,j] = (GameObject)Instantiate (tilePrefab, new Vector3(transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z), transform.rotation);
				grid [i, j].transform.parent = transform;
				grid [i, j].name = (char)('a' + j) + "" + (i+1);
				currCells += 1;
				if (i % 2 == 0)
				{
					if (currCells % 2 == 0) 
					{
						grid[i,j].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("vanilla_tile");
					} 
					else 
					{
						grid[i,j].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("wood_tile");
					}
				} 
				else 
				{
					if (currCells % 2 == 0) 
					{
						grid[i,j].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("wood_tile");
					} 
					else 
					{
						grid[i,j].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("vanilla_tile");
					}
				}
				// create chess pieces and set their initial position
				switch (i) 
				{
				case 0:
					if (j == 0 || j == 7)
						InstantiateChessPiece (1, grid [i, j],i,j, false);
					else if (j == 1 || j == 6)
						InstantiateChessPiece (2, grid [i, j],i,j, false);
					else if (j == 2 || j == 5)
						InstantiateChessPiece (3, grid [i, j],i,j, false);
					else if (j == 4)
						InstantiateChessPiece (4, grid [i, j],i,j, false);
					else
						InstantiateChessPiece (5, grid [i, j],i,j, false);
					break;
					case 1:
						InstantiateChessPiece (0, grid [i, j],i,j, false);
						break;
					case 6:
						InstantiateChessPiece (0, grid [i, j],i,j, true);
						break;
				case 7:
					if (j == 0 || j == 7)
						InstantiateChessPiece (1, grid [i, j],i,j, true);
					else if (j == 1 || j == 6)
						InstantiateChessPiece (2, grid [i, j],i,j, true);
					else if (j == 2 || j == 5)
						InstantiateChessPiece (3, grid [i, j],i,j, true);
					else if (j == 4)
						InstantiateChessPiece (4, grid [i, j],i,j, true);
					else
						InstantiateChessPiece (5, grid [i, j],i,j, true);
					break;
				}
				xOffset += distanceBetweenTiles;
			}
			yOffset += distanceBetweenTiles;
			xOffset = 0;
		}

	}

	// draws a diagonal red line over a cell whenever the mouse cursor is hovering over it
	private void drawSelected()
	{
		Debug.DrawLine (Vector3.up*selectionY + Vector3.right*selectionX,
						Vector3.up*(selectionY+1f) + Vector3.right*(selectionX+1f),
						Color.red);
	}
	// updates all of the moves a piece is allowed to make given the piece's position and the set of rules it must conform to given convential chess rules
	public void updateAllowedMoves(Piece piece)
	{
		List<Vector3> movementVectors = piece.MovementVectors;
		List<Cell> allowedCells = piece.ValidCells;
		if (piece.GetType() is Pawn) 
		{
			foreach (Vector3 vector in movementVectors) 
			{

			}
		} 
		else if (piece.GetType() is Knight) 
		{
			foreach (Vector3 vector in movementVectors) 
			{
				 
			}
		}
		else 
		{
			foreach (Vector3 vector in movementVectors) 
			{

			}
		}

	}

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
