using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PawnShift : Upgrade
{
	private BoardController boardController = GameController.gameController.boardController.GetComponent<BoardController>();

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}

	public void ApplyUpgrade () {
		Dictionary<string, Piece> playerPieces = boardController.PlayerTurn.MyPieces;

		// go through each piece belonging to the player of the current turn
		foreach (string key in playerPieces.Keys) {
			Piece p;
			// if piece is pawn, add one square sideways and one square backwards to its movement vectors
			if (playerPieces.TryGetValue (key, out p)) {
				if (p is Pawn) {
					if (!p.IsWhite) {
						Vector3[] v = { new Vector3 (0, 1, 0), new Vector3 (1, 0, 0), new Vector3 (-1, 0, 0) };
						p.MovementVectors.Add (v);
					} else {
						Vector3[] v = { new Vector3 (0, -1, 0), new Vector3 (1, 0, 0), new Vector3 (-1, 0, 0) };
						p.MovementVectors.Add (v);
					}
				}
			}
		}
	}

	public void RemoveUpgrade () {
		Dictionary<string, Piece> playerPieces = boardController.PlayerTurn.MyPieces;

		// go through each piece belonging to the player of the current turn
		foreach (string key in playerPieces.Keys) {
			Piece p;
			// if piece is pawn, reset its movement/capture vectors
			if (playerPieces.TryGetValue (key, out p)) {
				if (p is Pawn) {
					p.assignMovementVectors ();
				}
			}
		}
	}
}

