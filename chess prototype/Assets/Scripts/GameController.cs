using UnityEngine;
using System.Collections;

// This is a singleton controller class. It handles the core game logic that transforms our initial models, and it updates the game view based on these changes.
// There should never exist more than one of these during runtime. 
public class GameController : MonoBehaviour 
{
	private static GameController instance;
	public GameObject mainCamera;
	public GameObject selectedPiece;
	public GameObject grid;
	private PlayerController player;
	public GameStates curGameState;
	public TurnStates curTurnState;
	private int selectionX;
	private int selectionY;
	// a hit table that keeps track of a collision and a previous collision(columns) seperated by layers(rows)
	int layerListSize = 32;
	private RaycastHit2D[,] rayHitTable;


	public enum GameStates
	{
		MAIN_MENU, GAME_START ,IN_GAME, PAUSE, GAME_END
	};

	public enum TurnStates
	{
		TURN_START, CAN_SELECT, CAN_MOVE,
		IS_MOVING, HAS_MOVED, END_TURN,
		DEFAULT
	};

	// Runs regardless of whether the script is enabled or not (using for singleton behavior).
	void awake()
	{
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (transform.gameObject);
		} 
		else 
		{
			Debug.LogError ("Error: GameController instantiated twice, but GameController is a singleton class.");
			DestroyImmediate (this.gameObject);
		}
		
	}

	// Use this for initialization
	void Start () 
	{
		mainCamera = (GameObject)Instantiate (Resources.Load ("main_Camera"), new Vector3 (0, 0, 0), Quaternion.identity);		
		curGameState = GameStates.GAME_START;
		curTurnState = TurnStates.DEFAULT;

		// 31 is the max allowed number of Layers
		int layerSize = 32;
		rayHitTable = new RaycastHit2D [layerSize, 2];
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch (curGameState) 
		{
			case GameStates.MAIN_MENU:
			break;
			case GameStates.GAME_START:
			grid = (GameObject)Instantiate (Resources.Load ("obj_grid"), new Vector3 (0, 0, 0), Quaternion.identity);
			// instantiate our two players here
			// set random player to white, other to black here
			curGameState = GameStates.IN_GAME;
			break;
			case GameStates.IN_GAME:
			CenterCameraToBoard();
			switch (curTurnState)
			{
			case TurnStates.TURN_START:
				curTurnState = TurnStates.CAN_SELECT;
				break;
			case TurnStates.CAN_SELECT:
				UpdateCursorPos ();
				markCell ();
				// Layer9 = "PieceLayer"
				HighlightOnMouseCollision (8, Color.blue);
				HighlightOnMouseCollision (9, Color.yellow);
				selectPiece ();
				break;
			case TurnStates.CAN_MOVE:
				HighlightOnMouseCollision (8, Color.blue);
				UpdateCursorPos ();
				deselectPiece ();
				break;
			case TurnStates.DEFAULT:
				curTurnState = TurnStates.TURN_START;
				break;
			}
			break;
			case GameStates.PAUSE:
			break;
			case GameStates.GAME_END:
			break;

		}
	}
	// updates the x and y of our cursor's current position and rounds the x and y to the lower integer bound
	private void UpdateCursorPos()
	{
		if (!mainCamera) 
		{
			Debug.Log ("No main camera, exiting.");
			return;
		}
		RaycastHit2D hit;
		hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero, LayerMask.GetMask ("bottom"));
		if (hit) {
			Debug.Log (hit.point);
			selectionX = Mathf.FloorToInt (hit.point.x);
			selectionY = Mathf.FloorToInt (hit.point.y);
		} 
		else 
		{
			selectionX = -1;
			selectionY = -1;
		}
	}
	public void makeSelection()
	{
		
	}
	//  sets a piece to be the selectedPiece whenever the user clicks on it
	public void selectPiece()
	{
		float gridOriginX = grid.GetComponent<Transform> ().position.x;
		float gridOriginY = grid.GetComponent<Transform> ().position.y;
		Grid scr_Grid = grid.GetComponent<Grid> ();
		bool mouseClicked = Input.GetMouseButtonDown (0);
		if (mouseClicked)
			Debug.Log ("Left mouse button pressed");
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
				curTurnState = TurnStates.CAN_MOVE;
			}

		}
	}
	public void deselectPiece()
	{
		bool mouseClicked = Input.GetMouseButtonDown (1);
		if (mouseClicked) 
		{
			Debug.Log ("Right mouse button pressed");	
			selectedPiece = null;
			curTurnState = TurnStates.CAN_SELECT;
		}
	}
	// A debug function. Draws a diagonal line across the board cell our cursor is currently on.
	public void markCell()
	{
		Debug.DrawLine (Vector3.up*selectionY + Vector3.right*selectionX,
			Vector3.up*(selectionY+1f) + Vector3.right*(selectionX+1f),
			Color.red);
	}

	// calls Highlight() whenever the cursor touches a gameObject on the specified layer.
	// if the cursor is no longer touching the object, it calls UndoHighlight() on the object.
	// if the cursor is touching a new object, the new object is highlighted
	// if the cursor is not touching a new object, no additional changes are made.
	// params: layer1 - the layer we want raycast to pay attention to, col - the color we wish to highlight the objects on this layer with.
	void HighlightOnMouseCollision(int layer1, Color col)
	{
		// calculate a vector from camera position to mouse position and store it
		Vector2 camPos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 mousePos = (Vector2)Input.mousePosition;
		int distance = 0;
		// get the current layer of the game object whom this script is a component of
		int layer = layer1;
		// set up a layer mask for the given layer (Raycast needs this to determine what layer to pay attention to)
		int layerMask1 = 1 << layer;
		rayHitTable[layer1, 0] = Physics2D.Raycast (camPos, Vector2.zero, Mathf.Infinity, layerMask1);
		if (rayHitTable [layer1, 0].collider != null) 
		{
			Debug.Log ("Colliding with object on layer 9");
			if (rayHitTable [layer1, 0].collider.gameObject.GetComponent<Highlighter> () != null) 
			{
				rayHitTable [layer1, 0].collider.gameObject.GetComponent<Highlighter> ().Highlight (col);
			}
			if (rayHitTable [layer1, 1].collider != null && rayHitTable [layer1, 1].collider.GetComponent<Highlighter>() && !rayHitTable [layer1, 1].collider.Equals (rayHitTable[layer1, 0].collider))
				rayHitTable [layer1, 1].collider.gameObject.GetComponent<Highlighter> ().UndoHighlight ();
		} 
		else if (rayHitTable [layer1, 1].collider != null && rayHitTable [layer1, 1].collider.gameObject.GetComponent<Highlighter> () != null) 
		{
			rayHitTable [layer1, 1].collider.gameObject.GetComponent<Highlighter> ().UndoHighlight ();
		}
		rayHitTable [layer1, 1] = rayHitTable[layer1, 0];
	}

	private void CenterCameraToBoard()
	{
		
		if (grid != null && mainCamera != null) 
		{
			
			Grid grid_scr = grid.GetComponent<Grid> ();
			Transform gridTransform = grid.GetComponent<Transform> ();
			Vector3 gridCenterVector = new Vector3 (grid_scr.NumOfColumns/2, grid_scr.NumOfRows/2, 0);
			Debug.Log (grid_scr.NumOfColumns);
			Debug.Log (grid_scr.NumOfColumns / 2);
			Debug.Log (gridCenterVector);
			mainCamera.GetComponent<Transform>().position = ( new Vector3 (gridTransform.position.x, gridTransform.position.y, -10) ) + gridCenterVector;
		}
	}

	static public GameController Instance 
	{
		get{ return instance; }
		set{ ; }
	}
}
