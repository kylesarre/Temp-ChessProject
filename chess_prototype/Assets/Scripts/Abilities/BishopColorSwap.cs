using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BishopColorSwap : Upgrade
{
	// Use this for initialization
	void Start () {
		energyCost = 7;
	}

	// Update is called once per frame
	void Update () {
	}

	public override void ApplyUpgrade () {
		if (!SpendEnergy())
			return;

		Dictionary<string, Piece> playerPieces = boardController.PlayerTurn.MyPieces;

		// go through each piece belonging to the player of the current turn
		foreach (string key in playerPieces.Keys) {
			Piece p;
			// if piece is bishop, add one square sideways and backwards to its movement vectors
			if (playerPieces.TryGetValue (key, out p)) {
				if (p is Bishop) {
					Cell currCell = p.GetComponentInParent<Cell> ();
					Grid gridScript = boardController.grid.GetComponent<Grid> ();
					Vector3[] v = { new Vector3 (0, 1, 0), new Vector3 (0, -1, 0), new Vector3 (1, 0, 0), new Vector3 (-1, 0, 0) };
					foreach (Vector3 vecs in v)
					{
						// adding straight to movement vectors for bishops would cause scaling/capturing,
						// so add cells directly to visitable cells table
						Cell destCell = gridScript.grid [currCell.column + (int)vecs.x, currCell.row + (int)vecs.y].GetComponent<Cell> ();
						if(destCell.MyPiece == null)
							p.VisitableCells.Add (destCell);
					}
				}
			}
		}
	}

	public override void RemoveUpgrade () {
		Dictionary<string, Piece> playerPieces = boardController.PlayerTurn.MyPieces;

		// go through each piece belonging to the player of the current turn
		foreach (string key in playerPieces.Keys) {
			Piece p;
			// if piece is bishop, reset its movement/capture vectors
			if (playerPieces.TryGetValue (key, out p)) {
				if (p is Bishop) {
					p.assignMovementVectors ();
				}
			}
		}
	}
}

