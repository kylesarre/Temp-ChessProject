using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BoardController : MonoBehaviour 
{
	public GameObject selectedPiece;
	public GameObject grid;
	public GameObject board_Prefab;
	public GameObject tile_Prefab;

	private Highlighter highlighter;
	public List<GameObject> chessPiecePrefab;

	private int selectionX;
	private int selectionY;

	private Dictionary<string, List<string>> threatTable;

	// Use this for initialization
	void Start () 
	{
		selectedPiece = null;
		highlighter = GetComponent<Highlighter> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		UpdateCursorPos ();
		if (grid == null) 
		{
			createBoard ();
		}
		//Debug.Log (GameController.gameController);
		if (GameController.gameController != null) 
		{
			if (GameController.gameController.curTurnState == GameController.TurnStates.CAN_SELECT) 
			{
				selectPiece ();
				highlighter.UpdateHighlightableOnMouseCollision (9, Color.yellow);
				highlighter.UpdateHighlightableOnMouseCollision (8, Color.blue);
			} 
			else if (GameController.gameController.curTurnState == GameController.TurnStates.CAN_MOVE) 
			{
				deselectPiece ();
				highlighter.UpdateHighlightableOnMouseCollision (8, Color.blue);
			}
		}
	}

	private void createBoard()
	{
		grid = (GameObject)Instantiate (board_Prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
		grid.transform.parent = transform;

		Grid grid_scr = grid.GetComponent<Grid> ();
		int i,j;
		float xOffset, yOffset;
		xOffset = yOffset = 0.00f;
		int currCells = 0;

		for (i = 0; i < grid_scr.NumOfRows; i++) 
		{
			for (j = 0; j < grid_scr.NumOfColumns; j++) 
			{
				// instantiate board cells, assign associated sprite
				grid_scr.grid [i,j] = (GameObject)Instantiate (tile_Prefab, new Vector3(transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z), transform.rotation);
				grid_scr.grid [i, j].transform.parent = grid.transform;
				setCellCenter (grid_scr.grid [i, j]);
				grid_scr.grid [i, j].GetComponent<Cell> ().row = i;
				grid_scr.grid [i, j].GetComponent<Cell>().column = j;
				grid_scr.grid [i, j].name = (char)('a' + j) + "" + (i+1);
				currCells += 1;
				if (i % 2 == 0)
				{
					if (currCells % 2 == 0) 
					{
						grid_scr.grid[i,j].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("vanilla_tile_edit1");
					} 
					else 
					{
						grid_scr.grid[i,j].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("wood_tile");
					}
				} 
				else 
				{
					if (currCells % 2 == 0) 
					{
						grid_scr.grid[i,j].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("wood_tile");
					} 
					else 
					{
						grid_scr.grid[i,j].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("vanilla_tile_edit1");
					}
				}
				// create chess pieces and set their initial position
				switch (i) 
				{
				case 0:
					if (j == 0 || j == 7)
						InstantiateChessPiece (1, grid_scr.grid [i, j], false);
					else if (j == 1 || j == 6)
						InstantiateChessPiece (2, grid_scr.grid [i, j], false);
					else if (j == 2 || j == 5)
						InstantiateChessPiece (3, grid_scr.grid [i, j], false);
					else if (j == 4)
						InstantiateChessPiece (4, grid_scr.grid [i, j], false);
					else
						InstantiateChessPiece (5, grid_scr.grid [i, j], false);
					break;
				case 1:
					InstantiateChessPiece (0, grid_scr.grid [i, j], false);
					break;
				case 6:
					InstantiateChessPiece (0, grid_scr.grid [i, j], true);
					break;
				case 7:
					if (j == 0 || j == 7)
						InstantiateChessPiece (1, grid_scr.grid [i, j], true);
					else if (j == 1 || j == 6)
						InstantiateChessPiece (2, grid_scr.grid [i, j], true);
					else if (j == 2 || j == 5)
						InstantiateChessPiece (3, grid_scr.grid [i, j], true);
					else if (j == 4)
						InstantiateChessPiece (4, grid_scr.grid [i, j], true);
					else
						InstantiateChessPiece (5, grid_scr.grid [i, j], true);
					break;
				}
				xOffset += grid_scr.distanceBetweenTiles;
			}
			yOffset += grid_scr.distanceBetweenTiles;
			xOffset = 0;
		}

	}

	private void setCellCenter(GameObject cell)
	{
		Grid grid_scr = grid.GetComponent<Grid> ();
		Cell cell_scr = cell.GetComponent<Cell> ();
		Vector3 origin = cell.GetComponent<Transform> ().position;
		Vector3 endPoint = origin + new Vector3(grid_scr.distanceBetweenTiles, grid_scr.distanceBetweenTiles, 0);
		cell_scr.CellMidPoint = (origin + endPoint) / 2;
	}

	// instantiates the specified chess piece prefab at the specified location
	// indexes: 0 [Pawn], 1[rook], 2[knight], 3[Bishop], 4[Queen], 5[King]
	// location: the cell where the Piece resides
	// isWhite: true whenever the piece is for player White, false when the piece is for player Black
	private void InstantiateChessPiece(int index, GameObject cell, bool isWhite)
	{
		Cell cell_scr = cell.GetComponent<Cell> ();
		// we want the piece to spawn at the center of its specified cell, so we call this function and store the data
		GameObject newPiece = (GameObject)Instantiate (chessPiecePrefab[index], cell_scr.CellMidPoint, Quaternion.identity);
		newPiece.transform.parent = cell.transform;
		cell.GetComponent<Cell>().MyPiece = newPiece; 

		// now we can set all the fields of our Piece
		if(newPiece.GetComponent<Piece>() != null)
		{
			Piece pieceScript = newPiece.GetComponent<Piece> ();
			pieceScript.isWhite = isWhite;
			pieceScript.enabled = true;
		}
		else
		{
			Debug.LogError("Error: the prefab at chessPiecePrefab["+index+"] does not contain a Piece script. Objects in this collection must have a Piece component.");
		}
	}

	// updates the x and y of our cursor's current position on the board and rounds the x and y to the lower integer bound
	private void UpdateCursorPos()
	{
		if ( !Camera.main ) 
		{
			Debug.Log ("No main camera, exiting.");
			return;
		}
		RaycastHit2D hit;
		hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero, LayerMask.GetMask ("bottom"));
		if (hit) 
		{
			selectionX = Mathf.FloorToInt (hit.point.x);
			selectionY = Mathf.FloorToInt (hit.point.y);
		} 
		else 
		{
			selectionX = -1;
			selectionY = -1;
		}
	}
	public void selectPiece()
	{
		float gridOriginX = grid.GetComponent<Transform> ().position.x;
		float gridOriginY = grid.GetComponent<Transform> ().position.y;
		Grid scr_Grid = grid.GetComponent<Grid> ();
		bool mouseClicked = Input.GetMouseButtonDown (0);
		if (mouseClicked)
		if (selectionX >= gridOriginX &&
			selectionX < gridOriginX + scr_Grid.NumOfColumns &&
			selectionY >= gridOriginY &&
			selectionY < gridOriginY + scr_Grid.NumOfRows &&
			mouseClicked) 
		{
			Cell scr_Cell = scr_Grid.grid [selectionY, selectionX].GetComponent<Cell>();
			selectedPiece = scr_Cell.MyPiece;
			if (selectedPiece != null) 
			{
				updateVisitableCells (selectedPiece);
				highlighter.HighlightVisitableCells (selectedPiece);
				GameController.gameController.curTurnState = GameController.TurnStates.CAN_MOVE;

			}

		}
	}
	public void deselectPiece()
	{
		bool mouseClicked = Input.GetMouseButtonDown (1);
		if (mouseClicked) 
		{	
			highlighter.UndoHighlightVisitableCells (selectedPiece);
			selectedPiece = null;
			GameController.gameController.curTurnState = GameController.TurnStates.CAN_SELECT;
		}
	}

	public void updateVisitableCells(GameObject piece)
	{
		Cell cell_scr = piece.GetComponentInParent<Cell>();
		Grid grid_scr = grid.GetComponent<Grid> ();
		Piece piece_scr = piece.GetComponent<Piece> ();
		if (piece_scr is Pawn) 
		{
			Pawn pawn_scr = (Pawn)piece_scr;
			pawn_scr.ValidCells.Clear ();
			int scaleMax = 1;
			if (!pawn_scr.hasMoved)
				scaleMax = 2;
			foreach (Vector3 vector in piece_scr.MovementVectors)
			{
				for (int i = 1; i <= scaleMax; i++) 
				{
					Vector3 distance = vector * i;
					Debug.Log (distance);
					GameObject destinationCell = grid_scr.grid [cell_scr.row + (int)distance.y , cell_scr.column + (int)distance.x];
					Cell destCell_scr = destinationCell.GetComponent<Cell> ();
					if (destCell_scr.MyPiece != null)
						return;
					else 
					{
						Debug.Log (destinationCell.name);
						pawn_scr.ValidCells.Add (destCell_scr);
					}
						
				}
			}
		}
	}
}
