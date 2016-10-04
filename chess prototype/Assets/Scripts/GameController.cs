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
			instance = this;
		else
			DestroyImmediate (this.gameObject);
	}

	// Use this for initialization
	void Start () 
	{
		mainCamera = (GameObject)Instantiate (Resources.Load ("main_Camera"), new Vector3 (0, 0, 0), Quaternion.identity);		
		curGameState = GameStates.GAME_START;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (curGameState == GameStates.GAME_START) {
			grid = (GameObject)Instantiate (Resources.Load ("obj_grid"), new Vector3 (0, 0, 0), Quaternion.identity);
			// instantiate our two players
			// set random player to white, other to black
			curGameState = GameStates.IN_GAME;
		} 
		else if (curGameState == GameStates.IN_GAME) 
		{
			CenterCameraToBoard();
			startTurn ();
		}
	}

	private void startTurn()
	{
		curTurnState = TurnStates.TURN_START;
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
