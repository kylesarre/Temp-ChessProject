using UnityEngine;
using System.Collections;

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

	void awake()
	{
		if (instance == null) 
		{
			instance = this;
			DontDestroyOnLoad (transform.gameObject);
		}
		else
			DestroyImmediate (this.gameObject);
		
	}

	// Use this for initialization
	void Start () 
	{
		mainCamera = (GameObject)Instantiate (Resources.Load ("main_Camera"), new Vector3 (0, 0, 0), Quaternion.identity);		
		curGameState = GameStates.GAME_START;
		curTurnState = TurnStates.DEFAULT;
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
			// instantiate our two players
			// set random player to white, other to black
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
				selectPiece ();
				break;
				case TurnStates.CAN_MOVE:
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
	public void markCell()
	{
		Debug.DrawLine (Vector3.up*selectionY + Vector3.right*selectionX,
			Vector3.up*(selectionY+1f) + Vector3.right*(selectionX+1f),
			Color.red);
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
