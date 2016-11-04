using UnityEngine;
using System.Collections;

// This is a singleton class. It handles the state of the game, the game camera, and messaging between the sub-controllers in the game.
// There should never exist more than one of these during runtime. 
public class GameController : MonoBehaviour 
{
	public static GameController gameController;
	private PlayerController player;
	private UIController uiController;
	private GameObject boardController;
	public GameStates curGameState;
	public TurnStates curTurnState;
	public GameObject mainCamera;

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
	void Awake()
	{
		if (gameController == null) {
			gameController = this;

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
		Debug.Log (gameController);
		mainCamera = (GameObject)Instantiate (Resources.Load ("main_camera"), new Vector3 (0, 0, 0), Quaternion.identity);		
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
			boardController = (GameObject)Instantiate(Resources.Load("obj_BoardController"), new Vector3 (0, 0, 0), Quaternion.identity);
			//boardController.grid = (GameObject)Instantiate (Resources.Load ("obj_grid"), new Vector3 (0, 0, 0), Quaternion.identity);
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
				//UpdateCursorPos ();
				// Layer9 = "PieceLayer"
				//HighlightOnMouseCollision (8, Color.blue);
				//HighlightOnMouseCollision (9, Color.yellow);
				//selectPiece ();
				break;
			case TurnStates.CAN_MOVE:
				//HighlightOnMouseCollision (8, Color.blue);
				//UpdateCursorPos ();
				//deselectPiece ();
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
	private void CenterCameraToBoard()
	{
		BoardController boardController_scr = boardController.GetComponent<BoardController> ();
		if (boardController != null && mainCamera != null) 
		{
			if (boardController_scr.grid != null) 
			{

				Grid grid_scr = boardController_scr.grid.GetComponent<Grid>();
				Transform gridTransform = boardController_scr.grid.GetComponent<Transform> ();
				Vector3 gridCenterVector = new Vector3 (grid_scr.NumOfColumns/2, grid_scr.NumOfRows/2, 0);
				mainCamera.GetComponent<Transform>().position = ( new Vector3 (gridTransform.position.x, gridTransform.position.y, -10) ) + gridCenterVector;
			}
		}

	}
}
