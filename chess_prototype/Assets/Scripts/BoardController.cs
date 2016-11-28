using UnityEngine;
using System.Collections.Generic;

/****************************************************************************************/
/*
/* FILE NAME: BoardController
/*
/* DESCRIPTION: Controls the logic of the board and its pieces: receives input and updates the board and pieces accordingly. Signals the game controller to transition to new states when certain events occur.
/*
/* REFERENCE:
/*
/* DATE BY CHANGE REF DESCRIPTION
/* ======== ======= =========== =============
/* 
/* 
/*
/*
/*
/****************************************************************************************/

public class BoardController : MonoBehaviour 
{
	public GameObject selectedPiece;
	public GameObject grid;
	public GameObject board_Prefab;
	public GameObject tile_Prefab;

	private Player playerTurn;
	private Highlighter highlighter;
	public List<GameObject> chessPiecePrefab;

	private int selectionX;
	private int selectionY;

	public Dictionary<string, List<string>> threatTable;

	// Use this for initialization
	void Start () 
	{
		selectedPiece = null;
		highlighter = GetComponent<Highlighter> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GameController.gameController.curGameState == GameController.GameStates.GAME_START) 
		{
			GameStart ();
			GameController.gameController.setGameState (GameController.GameStates.IN_GAME);
		} 
		else if (GameController.gameController.curGameState == GameController.GameStates.IN_GAME) 
		{
			UpdateCursorPos ();
			if(GameController.gameController.curTurnState == GameController.TurnStates.DEFAULT)
				GameController.gameController.setTurnState (GameController.TurnStates.TURN_START);	
		}
		if (GameController.gameController.curTurnState == GameController.TurnStates.TURN_START) 
		{
			GameController.gameController.curTurnState = GameController.TurnStates.CAN_SELECT;
		}
		if (GameController.gameController.curTurnState == GameController.TurnStates.CAN_SELECT) 
		{
			SelectCell ();
			highlighter.UpdateHighlightableOnMouseCollision (8, Color.blue);
		} 
		else if (GameController.gameController.curTurnState == GameController.TurnStates.CAN_MOVE) 
		{
			SelectCell ();
			highlighter.UpdateHighlightableOnMouseCollision (8, Color.blue);
			bool mouseClicked = Input.GetMouseButtonDown (1);
			if (mouseClicked) {	
				DeselectPiece ();
			}
		} 
		else if (GameController.gameController.curTurnState == GameController.TurnStates.HAS_MOVED) 
		{
			// updating pieces relevant to the move and their corresponding threat table entries would occur here
			GameController.gameController.curTurnState = GameController.TurnStates.END_TURN;
		}
		else if(GameController.gameController.curTurnState == GameController.TurnStates.END_TURN)
		{
			PlayerController playerController = GameController.gameController.playerController.GetComponent<PlayerController> ();
			playerController.NextPlayer ();
			playerTurn = playerController.WhoseTurn ();
			GameController.gameController.curTurnState = GameController.TurnStates.TURN_START;
		}
	}
	// instantiates crucial game elements for our game
	public void GameStart()
	{
		if (grid == null) 
			CreateBoard ();
		PlayerController playerController = GameController.gameController.playerController.GetComponent<PlayerController> ();
		playerController.AssignPieces ();
		playerTurn = playerController.WhoseTurn ();
		BuildThreatTable ();
	}
	// generates an 8x8 chess board and all chess pieces; sets up the board and pieces 
	private void CreateBoard()
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
				SetCellCenter (grid_scr.grid [i, j]);
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
						InstantiateChessPiece (1, grid_scr.grid [i, j], false,j);
					else if (j == 1 || j == 6)
						InstantiateChessPiece (2, grid_scr.grid [i, j], false,j);
					else if (j == 2 || j == 5)
						InstantiateChessPiece (3, grid_scr.grid [i, j], false,j);
					else if (j == 4)
						InstantiateChessPiece (4, grid_scr.grid [i, j], false,j);
					else
						InstantiateChessPiece (5, grid_scr.grid [i, j], false,j);
					break;
				case 1:
					InstantiateChessPiece (0, grid_scr.grid [i, j], false,j);
					break;
				case 6:
					InstantiateChessPiece (0, grid_scr.grid [i, j], true,j);
					break;
				case 7:
					if (j == 0 || j == 7)
						InstantiateChessPiece (1, grid_scr.grid [i, j], true,j);
					else if (j == 1 || j == 6)
						InstantiateChessPiece (2, grid_scr.grid [i, j], true,j);
					else if (j == 2 || j == 5)
						InstantiateChessPiece (3, grid_scr.grid [i, j], true,j);
					else if (j == 4)
						InstantiateChessPiece (4, grid_scr.grid [i, j], true,j);
					else
						InstantiateChessPiece (5, grid_scr.grid [i, j], true,j);
					break;
				}
				xOffset += grid_scr.distanceBetweenTiles;
			}
			yOffset += grid_scr.distanceBetweenTiles;
			xOffset = 0;
		}

	}
	// calculates the midpoint of the specified cell in world space
	// @param cell - a cell of the board
	private void SetCellCenter(GameObject cell)
	{
		Grid grid_scr = grid.GetComponent<Grid> ();
		Cell cell_scr = cell.GetComponent<Cell> ();
		Vector3 origin = cell.GetComponent<Transform> ().position;
		Vector3 endPoint = origin + new Vector3(grid_scr.distanceBetweenTiles, grid_scr.distanceBetweenTiles, 0);
		cell_scr.CellMidPoint = (origin + endPoint) / 2;
	}
	// instantiates the specified chess piece prefab at the specified location
	// @param - indexes: 0 [Pawn], 1[rook], 2[knight], 3[Bishop], 4[Queen], 5[King]
	// @param - location: the cell where the Piece resides
	// @param - isWhite: true whenever the piece is for player White, false when the piece is for player Black
	private void InstantiateChessPiece(int index, GameObject cell, bool isWhite, int pieceID)
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
            if(pieceScript is Pawn)
            {
                Pawn pawnScript = (Pawn)pieceScript;
                pawnScript.assignMovementVectors();
            }
			pieceScript.enabled = true;
		}
		else
		{
			Debug.LogError("Error: the prefab at chessPiecePrefab["+index+"] does not contain a Piece script. Objects in this collection must have a Piece component.");
		}
		if (isWhite)
			newPiece.name = index + "White" + pieceID;
		else
			newPiece.name = index + "Black" + pieceID;
	}
	private void BuildThreatTable()
	{
		Grid grid_scr = grid.GetComponent<Grid> ();
		threatTable = new Dictionary<string, List<string>>();
		// add all of the cells of the board and their corresponding list containers to our table
		foreach (GameObject cell in grid_scr.grid) 
		{
			threatTable.Add (cell.name, new List<string>());
		}

		PlayerController playerController = GameController.gameController.playerController.GetComponent<PlayerController>();
		foreach (string keyA in playerController.white.MyPieces.Keys) 
		{
			// iterate through each piece of the white player
			Piece piece;
			// grab the cell corresponding to the piece name
			playerController.white.MyPieces.TryGetValue (keyA, out piece);
			UpdatePiece (piece);
			// get the piece from the cell
			foreach(string keyB in piece.ThreatenedCells.Keys)
			{
				List<string> threatList;
				threatTable.TryGetValue (keyB, out threatList);
				threatList.Sort ();
				if (!threatList.Contains(piece.name)) 
				{
					threatList.Add (piece.name);
				}
				threatTable [keyB] = threatList;
			}
		}
		foreach (string keyA in playerController.black.MyPieces.Keys) 
		{
			// iterate through each piece of the white player
			Piece piece;
			// grab the cell corresponding to the piece name
			playerController.black.MyPieces.TryGetValue (keyA, out piece);
			UpdatePiece (piece);
			// get the piece from the cell
			foreach(string keyB in piece.ThreatenedCells.Keys)
			{
				List<string> threatList;
				threatTable.TryGetValue (keyB, out threatList);
				threatList.Sort ();
				if (!threatList.Contains(piece.name)) 
				{
					threatList.Add (piece.name);
				}
				threatTable [keyB] = threatList;
			}
		}
		foreach (string key in threatTable.Keys) 
		{
			List<string> thrPieces = new List<string> ();
			threatTable.TryGetValue (key, out thrPieces);
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
	// sets the selectedCell to the cell underneath the mouse cursor whenever the left mouse button is pressed
	// adds a highlight to the piece of the selected cell
	public void SelectCell()
	{
		float gridOriginX = grid.GetComponent<Transform> ().position.x;
		float gridOriginY = grid.GetComponent<Transform> ().position.y;
		Grid scr_Grid = grid.GetComponent<Grid> ();
		bool mouseClicked = Input.GetMouseButtonDown (0);
		if (mouseClicked) 
		{
			if (selectionX >= gridOriginX &&
			    selectionX < gridOriginX + scr_Grid.NumOfColumns &&
			    selectionY >= gridOriginY &&
			    selectionY < gridOriginY + scr_Grid.NumOfRows &&
			    mouseClicked) 
			{
				GameObject cell = scr_Grid.grid [selectionY, selectionX];
				Cell scr_Cell = cell.GetComponent<Cell>();
				if (GameController.gameController.curTurnState == GameController.TurnStates.CAN_SELECT) 
				{
					if( scr_Cell.MyPiece != null && DoesColorMatchPlayer(playerTurn, scr_Cell.MyPiece.GetComponent<Piece>()) )
					{
						selectedPiece = scr_Cell.MyPiece;
					}
					if (selectedPiece != null) 
					{
                        //UpdatePiece (selectedPiece.GetComponent<Piece>());
                        List<Cell> vcells = selectedPiece.GetComponent<Piece>().VisitableCells;
						highlighter.HighlightVisitableCells (selectedPiece);
						highlighter.AddHighlight (selectedPiece, Color.yellow);
						GameController.gameController.curTurnState = GameController.TurnStates.CAN_MOVE;
					}
				} 
				else if (GameController.gameController.curTurnState == GameController.TurnStates.CAN_MOVE) 
				{
					// if the player clicks on one of their own pieces while a piece is selected
					if (scr_Cell.MyPiece != null && DoesColorMatchPlayer (playerTurn, scr_Cell.MyPiece.GetComponent<Piece> ())) {
						if (scr_Cell.MyPiece.Equals (selectedPiece)) {
							// if the player clicks on the piece that's already selected, deselect piece
							DeselectPiece ();
						} else {
							// if the player clicks on a different piece of the same color, deselect piece
							// then select the new piece
							DeselectPiece ();
							SelectCell ();
						}
					} else {
						// else, if the player clicks an empty cell, attempt to move to the cell.
						// invalid moves are handled by the Move method
						Move (cell);
					}
				}
			}
		}
	}
	// undoes the highlight on the selected piece and unassigns the selectedPiece
	public void DeselectPiece()
	{
		highlighter.UndoHighlightVisitableCells (selectedPiece);
		highlighter.RemoveHighlight (selectedPiece);
		selectedPiece = null;
		GameController.gameController.curTurnState = GameController.TurnStates.CAN_SELECT;
	}
	// updates the piece model to reflect the current state of the game (visitable cells, threatened cells)
	public void UpdatePiece(Piece piece_scr)
	{
		// save relevant components for this calculation
		Cell cell_scr = piece_scr.gameObject.GetComponentInParent<Cell>();
		Grid grid_scr = grid.GetComponent<Grid> ();
		// clear the list to modify the list for the current piece position
		piece_scr.VisitableCells.Clear ();
		piece_scr.ThreatenedCells.Clear();
		if (piece_scr is Pawn) 
		{
			// update the pawn's visitable cells based on its set of movement vectors (default: forward by one or two) and whether or not it has moved before
			Pawn pawn_scr = (Pawn)piece_scr;
			int scaleMax = 1;
			if (!pawn_scr.hasMoved)
				scaleMax = 2;
			bool doScaling = true; 
			GenerateVisitableCells( cell_scr, grid_scr, pawn_scr, doScaling, scaleMax);
			// update the pawn's visitable cells based on its capture vectors (default: diagonally left or right)
		} 
		else if (piece_scr is King || piece_scr is Knight) 
		{
			GenerateVisitableCells(cell_scr, grid_scr, piece_scr, false, 1);
		} 
		else 
		{
			GenerateVisitableCells(cell_scr, grid_scr, piece_scr, true, 8);
		}
	}
	// removes pieces from the threatTable whenever the piece's threatlist no longer includes a given cell (such as after a move)
	//@param Dictionary dict - the threatList of the specified piece
	//@param Piece piece_scr - the script of the specified piece
	public void TableRemove(Dictionary<string, Cell> dict, Piece piece_scr)
	{
		//Debug.Log ("table remove call on "+piece_scr.name);
		Dictionary<string, Cell> tempDict = new Dictionary<string, Cell>();
		foreach(string key in piece_scr.ThreatenedCells.Keys)
		{
			Cell cell;
			if (piece_scr.ThreatenedCells.TryGetValue (key, out cell)) 
			{
				tempDict.Add (key, cell);
			}
		}
		UpdatePiece (piece_scr);
		Dictionary<string, Cell> newDict = piece_scr.ThreatenedCells;
		Dictionary<string, Cell> interDict = new Dictionary<string, Cell> ();
		foreach(string key in tempDict.Keys)
		{
			Cell thrCell;
			if (newDict.TryGetValue (key, out thrCell)) 
			{
				interDict.Add (key, thrCell);
			}
		}
		 //we build a table that stores what we want to delete from the threat table
		 //for every key in the intersection of the old and new table, if we find 
		 //such a key in the old table, we will remove the entry from the old table
		foreach (string key in interDict.Keys) 
		{
			Cell thrCell;
			if (tempDict.TryGetValue (key, out thrCell)) 
			{
				tempDict.Remove (thrCell.name);
			}
		}
		// whatever is left in the tempDict is actually the entries we want to edit in the threatTable
		foreach(string key in tempDict.Keys)
		{
			List<string> thrPieces;
			threatTable.TryGetValue (key, out thrPieces);
			thrPieces.Remove (piece_scr.name);
			threatTable [key] = thrPieces;
		}

	}
	// checks the specified piece's threatLine, looks up the cells in the threat table
	// and then adds the specified piece's name to the threat table if it doesn't already exist.
	// @param Dictionary dict - the threatened cells of the specified piece
	// @param Piece piece_Scr - the piece whose threatened cells we wish to add to the table.
	public void TableAdd(Dictionary<string, Cell> dict, Piece piece_scr)
	{
		foreach (string key in dict.Keys) 
		{
//			if (piece_scr is Pawn)
//			{
//				Debug.Log (key + " " + piece_scr.name);
//			}
			Cell tcell;
			List<string> thrLine;
			if (dict.TryGetValue (key, out tcell)) 
			{
				threatTable.TryGetValue (tcell.name, out thrLine);
				if (!thrLine.Contains (piece_scr.name)) 
				{
//					Debug.Log (tcell.name +" "+ (!thrLine.Contains (piece_scr.name)));
//					Debug.Log (piece_scr.name + " of " + tcell);
					thrLine.Add (piece_scr.name);
				}
//				if (piece_scr is Pawn)
//				{
//					Debug.Log ("THRLINE1");
//					foreach (string name in thrLine)
//						Debug.Log (name);
//					Debug.Log ("THRLINE2");
//
//				}
				threatTable [tcell.name] = thrLine;
			}
		}

	}
	public void TableUpdate(Dictionary<string, Cell> dict, Piece piece_scr)
	{
		TableRemove (dict, piece_scr);
		TableAdd (dict, piece_scr);
	}
	// adds all cells that a piece can move to to its visitable cells list
	// @param Cell sourceCell_scr - the script attatched to the cell where the selected piece resides
	// @param Grid grid_scr - the script attatched to the grid
	// @param Piece selectedPiece_scr the script attatched to the selected piece
	// @param bool doScaling - true if we wish to scale the movement vectors of the selected piece
	// @param int maxScale - the maximum value we will scale a given vector by.
	private void GenerateVisitableCells( Cell sourceCell_scr, Grid grid_scr, Piece piece_scr, bool doScaling, int maxScale)
	{
		//Debug.Log (piece_scr.MovementVectors.Count);
		foreach (Vector3 distance in piece_scr.MovementVectors) 
		{
			int scale = 1;
			Vector3 newDistance = distance;
			bool pieceOccupies = false;
			bool applyScale = true;
			while (InRange (sourceCell_scr, newDistance, grid_scr) && !pieceOccupies && applyScale && (scale <= maxScale)) 
			{
				AddCell (sourceCell_scr, newDistance, grid_scr, piece_scr);
				GameObject destCell = grid_scr.grid [sourceCell_scr.row + (int)newDistance.y, sourceCell_scr.column + (int)newDistance.x];
				Cell destCell_scr = destCell.GetComponent<Cell> ();
				piece_scr.ThreatenedCells.Add (destCell_scr.gameObject.name, destCell_scr);
                //Debug.Log(piece_scr.name);
                foreach(Cell vcell in piece_scr.VisitableCells)
                {
//                    Debug.Log(vcell.name);
                }
				if (destCell_scr.MyPiece != null) 
				{
					pieceOccupies = true;
				}
				if (doScaling) 
				{
					scale++;
					newDistance = distance * scale;
				} 
				else
					applyScale = false;		
			}
		}
		foreach (Vector3 capVec in piece_scr.CaptureVectors) 
		{
			if (InRange (sourceCell_scr, capVec, grid_scr)) 
			{
				// the way a pawn can capture is different from every other piece. i specify what i mean by that here.
				GameObject destinationCell = grid_scr.grid [sourceCell_scr.row + (int)capVec.y, sourceCell_scr.column + (int)capVec.x];
				Cell destCell_scr = destinationCell.GetComponent<Cell> ();
				if(destCell_scr.MyPiece != null)
				if ((destCell_scr.MyPiece != null) && (!DoesColorMatchPiece (piece_scr, destCell_scr.MyPiece.GetComponent<Piece> ()))) 
				{
					piece_scr.VisitableCells.Add (destCell_scr);
				}
				piece_scr.ThreatenedCells.Add (destCell_scr.gameObject.name, destCell_scr);
			}
		}
	}
	// determines if a scaled vector is still within the board space
	// @param Cell cell_scr - the script attached to a cell game object (the cell the selected piece resides on)
	// @param Vector3 vector - a 3-dimensional vector (the scaled movement vector of the piece)
	// @param Grid grid_scr - the script attached to the grid game object
	// @return bool - if not within the board space, return false; if within the board space, return true
	private bool InRange(Cell cell_scr, Vector3 vector, Grid grid_scr)
	{
		return (cell_scr.row + (int)vector.y < grid_scr.NumOfRows &&
		cell_scr.row + (int)vector.y >= 0 &&
		cell_scr.column + (int)vector.x < grid_scr.NumOfColumns &&
		cell_scr.column + (int)vector.x >= 0);
	}
		
	// adds the specified cell to the the piece's visitable cells list
	// @param Cell sourceCell_scr - the cell where the piece is moving from
	// @param Cell destCell_scr - the cell that the piece is moving to
	// @param Grid grid_scr - the grid in which the move is occuring
	// @param Piece somePiece - the piece to be moved
	private void AddCell(Cell sourceCell_scr, Vector3 distance, Grid grid_scr, Piece somePiece)
	{
		GameObject destCell = grid_scr.grid [sourceCell_scr.row + (int)distance.y, sourceCell_scr.column + (int)distance.x];
		Cell destCell_scr = destCell.GetComponent<Cell> ();
		if (somePiece is Pawn) 
		{
			//somePiece.ThreatenedCells.Add (destCell_scr.gameObject.name, destCell_scr);
			if (destCell_scr.myPiece == null )
			{
				somePiece.VisitableCells.Add (destCell_scr);
			}
		} 
		else 
		{
			//somePiece.ThreatenedCells.Add (destCell_scr.gameObject.name, destCell_scr);
			if (destCell_scr.myPiece != null && !DoesColorMatchPiece (somePiece, destCell_scr.myPiece.GetComponent<Piece> ()))
			{
				somePiece.VisitableCells.Add (destCell_scr);
			}
            else if(destCell_scr.myPiece == null)
            {
                somePiece.VisitableCells.Add(destCell_scr);
            }
		}
	}
	// determines if the color of the player and the piece are the same
	// @param Player curPlayer - the player who is taking their turn
	// @param Piece piece - the piece to be compared with the player
	// @return true if the color matches, false if the color doesn't match
	public bool DoesColorMatchPlayer(Player curPlayer, Piece piece)
	{
		return (!( curPlayer.IsWhite^piece.isWhite) );  
	}
	public bool DoesColorMatchPiece(Piece destPiece, Piece srcPiece)
	{
		return !(destPiece.isWhite ^ srcPiece.isWhite);
	}
	// moves the selected cell to the specified destination cell
	// @param destCell - the destination cell
	private void Move (GameObject destCell)
	{
		Cell destCell_scr = destCell.GetComponent<Cell> ();
		if ( selectedPiece.GetComponent<Piece>().VisitableCells.Contains(destCell_scr) ) 
		{
            if (selectedPiece.GetComponent<Pawn>())
            {
                Pawn pawn_scr = selectedPiece.GetComponent<Pawn>();
                pawn_scr.hasMoved = true;
            }
            Cell sourceCell = selectedPiece.GetComponentInParent<Cell> ();
			// destroy is just for testing purposes; needs to be replaced with correct capturing code
			Destroy (destCell_scr.MyPiece);
			sourceCell.MyPiece = null;

            selectedPiece.transform.SetParent(destCell.transform, false);
			destCell_scr.MyPiece = selectedPiece;
            Piece piece_scr = selectedPiece.GetComponent<Piece>();
            DeselectPiece();
            MoveUpdate(sourceCell);
            //updateMoveLog ();
			TableUpdate(piece_scr.ThreatenedCells, piece_scr);
            MoveUpdate(destCell_scr);
            GameController.gameController.curTurnState = GameController.TurnStates.HAS_MOVED;
		}
	}
    // updates all pieces threatening the specified cell (to be used on the source and destination cell of a move)
    public void MoveUpdate(Cell cell)
    {
        List<string> threatList;
        if(threatTable.TryGetValue(cell.name, out threatList))
        {
            foreach(string pieceID in threatList)
            {
                GameObject piece = GameObject.Find(pieceID);
//              Debug.Log(piece.name);
                Piece piece_scr = piece.GetComponent<Piece>();
                //UpdatePiece(piece_scr);
				TableUpdate (piece_scr.ThreatenedCells, piece_scr);
            }
        }
    }
	public Player PlayerTurn
	{
		get{return playerTurn;}
	}

	// verifies that a piece at a given cell is locked in place (not allowed to move according to chess rules)
	// @return true if the cell is locked, false if the piece is not locked
//	public bool isLocked(Cell cell)
//	{
//		Cell kingCell;
//		bool found1 = playerTurn.MyPieces.TryGetValue ("King(Clone)", out kingCell);
//		List<Piece> thrPieces; 
//		bool found2 = threatTable.TryGetValue (cell.name, out thrPieces);
//		GameObject temp = cell.MyPiece;
//		cell.MyPiece = null;
//		foreach (Piece piece in thrPieces) 
//		{
//			UpdatePieceLists (piece);
//			Cell threatCell;
//			if (piece.ThreatenedCells.TryGetValue (kingCell.gameObject.name, out threatCell)) 
//			{
//				cell.MyPiece = temp;
//				UpdatePieceLists (piece);
//				return true;
//			}
//			cell.MyPiece = temp;
//			UpdatePieceLists (piece);
//		}
//
//		return false;
//	}
}
