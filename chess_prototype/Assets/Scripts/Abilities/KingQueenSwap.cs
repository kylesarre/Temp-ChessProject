using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class KingQueenSwap : Upgrade
{
	// Use this for initialization
	void Start () {
		energyCost = 15;
		gridScript = boardController.grid.GetComponent<Grid> ();
	}

	// Update is called once per frame
	void Update () {
	}

	// TODO FINISH THIS
	public override void ApplyUpgrade ()
	{
		if (!SpendEnergy())
			return;

		Dictionary<string, Piece> playerPieces = boardController.PlayerTurn.MyPieces;

		Cell kingCell = null;
		List<Cell> queenCells = new List<Cell>();	// if player has promoted one or more pawns to queens

		// go through each piece belonging to the player of the current turn
		foreach (string key in playerPieces.Keys) {
		Piece p;
		// if piece is queen or king, store the cell it is located in
			if (playerPieces.TryGetValue (key, out p)) {
				if (p is King) {
					kingCell = p.GetComponentInParent<Cell> ();
					Debug.Log (p.GetComponentInParent<Cell> ().name + " set for kingCell");
				} else if(p is Queen) {
					queenCells.Add(p.GetComponentInParent<Cell> ());
					Debug.Log (p.GetComponentInParent<Cell> ().name + " added to queenCells");
				}
			}
		}

		// if any friendly queens exist
		if (queenCells.Count > 0) {
			int minDistance = 4;
			Cell closestQueen = null;
			foreach (Cell c in queenCells) {
				int queenDist = (Math.Abs(c.row - kingCell.row) + Mathf.Abs((c.column - kingCell.column)));
				if (queenDist <= 3 && queenDist < minDistance) {
					// if there's a friendly queen 3 or fewer squares away, and it's closer than
					// any other queen tested, make note of its cell
					closestQueen = c;
				} else if (queenDist <= 3 && queenDist == minDistance) {
					// if multiple friendly queens are equidistant, just pick one randomly.
					// this is an edge case we just don't have time to properly deal with.
					System.Random rand = new System.Random();
					if (rand.NextDouble() > 0.5)
						closestQueen = c;
				}
			}
			if (minDistance <= 3 && closestQueen != null && kingCell != null) {
				// swap the closest queen and king's game objects
				GameObject queenTemp = closestQueen.MyPiece;

				closestQueen.MyPiece = kingCell.MyPiece;
				kingCell.MyPiece = queenTemp;

				// swap the king and queen's transforms
				Transform transTemp = closestQueen.MyPiece.transform;

				closestQueen.MyPiece.transform = kingCell.MyPiece.transform;
				kingCell.MyPiece.transform = transTemp;
			}
		}
	}
}