using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PawnStraightCapture : MonoBehaviour
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

		foreach (string key in playerPieces.Keys) {
			Piece p;
			// if piece is pawn, add one square directly forward to its capture vectors
			if (playerPieces.TryGetValue (key, out p)) {
				if (p is Pawn) {
					if (!p.IsWhite)
						p.CaptureVectors.Add (new Vector3 (0, 1, 0));
					else
						p.CaptureVectors.Add (new Vector3 (0, -1, 0));
				}
			}
		}
	}

	public void RemoveUpgrade () {
		Dictionary<string, Piece> playerPieces = boardController.PlayerTurn.MyPieces;

		foreach (string key in playerPieces.Keys) {
			Piece p;
			// if piece is pawn, add one square directly forward to its capture vectors
			if (playerPieces.TryGetValue (key, out p)) {
				if (p is Pawn) {
					p.assignMovementVectors ();
				}
			}
		}
	}
}

