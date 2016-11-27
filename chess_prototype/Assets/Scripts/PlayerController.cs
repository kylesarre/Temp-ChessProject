using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/****************************************************************************************/
/*
/* FILE NAME: PlayerController
/*
/* DESCRIPTION: Controls the logic regarding player turn order and color and updates the models of the players in the game
/*
/* REFERENCE:
 * 
 * 
/*
/* DATE BY CHANGE REF DESCRIPTION
/* ======== ======= =========== =============
/* 
/* 
/*
/*
/*
/****************************************************************************************/

public class PlayerController : MonoBehaviour 
{
	private Queue<Player> players;
	public GameObject obj_Player;
	public GameObject player1;
	public GameObject player2;

	public Player player1_scr;
	public Player player2_scr;

	public Player white;
	public Player black;


	void Awake()
	{
		player1 = (GameObject)Instantiate (obj_Player,new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
		player2 = (GameObject)Instantiate (obj_Player,new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);

		player1_scr = player1.GetComponent<Player> ();
		player2_scr = player2.GetComponent<Player> ();

		players = new Queue<Player> ();
	}

	// Use this for initialization
	void Start ()  
	{
		AssignRandomColor ();
		PopulateQueue ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	// assigns a name to the player class
	// @param: Player player - the player whose name we wish to assign
	// @param String name - the name we wish to assign to this player
	public void AssignName(Player player, string name)
	{
		player.PlayerName = name;
	}
	// flips a coin and determines which player is white depending on outcome
	public void AssignRandomColor()
	{
		int randomInt = Random.Range (0, 2);
		if (randomInt == 0) 
		{
			player1_scr.IsWhite = true;
			player2_scr.IsWhite = false;
			white = player1_scr;
			black = player2_scr;
		}
		else
		{
			player1_scr.IsWhite = false;
			player2_scr.IsWhite = true;
			white = player2_scr;
			black = player1_scr;

		}
	}
	// builds a dictionary of pieces for each player, which can be looked up by the name of the piece.
	public void AssignPieces()
	{
		Grid grid = GameController.gameController.boardController.GetComponent<BoardController> ().grid.GetComponent<Grid> ();
		for (int i = 0; i < grid.NumOfColumns-6; i++) 
		{
			for (int j = 0; j < grid.NumOfColumns; j++) 
			{
				Cell cell = grid.grid [i, j].GetComponent<Cell>();
				Piece piece = cell.MyPiece.GetComponent<Piece> ();
				black.MyPieces.Add (piece.name, piece);
			}
		}
		for (int i = 6; i < grid.NumOfRows; i++) 
		{
			for (int j = 0; j < grid.NumOfColumns; j++) 
			{
				Cell cell = grid.grid [i, j].GetComponent<Cell>();
				Piece piece = cell.MyPiece.GetComponent<Piece> ();
				white.MyPieces.Add (piece.name, piece);
			}
		}
		//printMyPieces (white);
		//printMyPieces (black);
	}
	// logs the MyPieces table that corresponds to the specified player
	public void printMyPieces(Player player)
	{
		foreach (string key in player.MyPieces.Keys) 
		{
			Piece piece;
			if(player.MyPieces.TryGetValue (key, out piece))
			{
				Debug.Log ("Looking up piece by " + key + ", found piece by the name:" + piece.name);
			}
		}
	}
	// adds both players to the queue, starting with whichever player is currently White
	public void PopulateQueue()
	{
		players.Enqueue (white);
		players.Enqueue (black);
	}
	// moves the next player to the beginning of the queue, while moving the current player to the back
	public void NextPlayer()
	{
		players.Enqueue (players.Dequeue ());
		WhoseTurn ().Energy++;
		Debug.Log (WhoseTurn().IsWhite + " " + WhoseTurn().Energy);
	}
	public Player WhoseTurn()
	{
		return players.Peek ();
	}
}