using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PawnStraightCapture : Upgrade
{
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public override void ApplyUpgrade () {
		Dictionary<string, Piece> playerPieces = boardController.PlayerTurn.MyPieces;

		// go through each piece belonging to the player of the current turn
		foreach (string key in playerPieces.Keys) {
			Piece p;
			// if piece is pawn, add one square forward to its capture vectors
			if (playerPieces.TryGetValue (key, out p)) {
				if (p is Pawn) {
					if (!p.IsWhite)
						p.CaptureVectors.Add (new Vector3 (0, -1, 0));
					else
						p.CaptureVectors.Add (new Vector3 (0, 1, 0));
				}
			}
		}
	}

	public override void RemoveUpgrade () {
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

