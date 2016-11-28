using UnityEngine;
using System.Collections;

// This is a singleton class. It handles the state of the game, the game camera, and messaging between the sub-controllers in the game.
// There should never exist more than one of these during runtime. 
public class GameController : MonoBehaviour 
{
	public static GameController gameController;
	public GameObject playerController;
	public UIController uiController;
	public GameObject boardController;
	public GameStates curGameState;
	public TurnStates curTurnState;

	public Camera mainCamera;

	public enum GameStates
	{
		MAIN_MENU, GAME_START, IN_GAME, PAUSE, GAME_END
	};

	public enum TurnStates
	{
		TURN_START, CAN_SELECT, CAN_MOVE,
		HAS_MOVED, END_TURN,
		DEFAULT
	};
		
	// ensures exactly one instance of this controller is instantiated before game starts
	void Awake()
	{
		gameController = this;
//////		if (gameController == null) {
//////			gameController = this;
//////
//////			DontDestroyOnLoad (transform.gameObject);
////		} 
////		else 
//		{
//			Debug.LogError ("Error: GameController instantiated twice, but GameController is a singleton class.");
//			DestroyImmediate (this.gameObject);
//		}	
	}
		

	//Initializes class variables upon instantiation 
	void Start () 
	{
		if (Camera.main != null)
			mainCamera = Camera.main;
		else
			mainCamera = ((GameObject)Instantiate (Resources.Load ("main_camera"), new Vector3 (0, 0, 0), Quaternion.identity)).GetComponent<Camera>();
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
			if(boardController == null)
				boardController = (GameObject)Instantiate (Resources.Load ("obj_BoardController"), new Vector3 (0, 0, 0), Quaternion.identity);
			if(playerController == null)
				playerController = (GameObject)Instantiate (Resources.Load ("obj_PlayerController"), new Vector3 (0, 0, 0), Quaternion.identity);
			break;
			case GameStates.IN_GAME:
			CenterCameraToBoard();
			break;
			case GameStates.PAUSE:
			break;
			case GameStates.GAME_END:
			break;

		}
	}
	// If a camera is found in the scene and we are in a game, this function centers the camera to the board in the game
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
				mainCamera.orthographicSize = 6;
			}
		}

	}
	// sets the game state to the specified game state
	// @param state - the gamestate the system should transition to.
	public void setGameState(GameStates state)
	{
		curGameState = state;
	}
	// sets the turn state to the specified turn state
	// @param state - the turn state the system should transition to.
	public void setTurnState(TurnStates state)
	{
		curTurnState = state;
	}
}