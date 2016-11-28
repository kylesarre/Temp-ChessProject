using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KingQueenSwap : Upgrade
{

	// Use this for initialization
	void Start () {
		energyCost = 15;
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

		Cell kingCell;
		List<Cell> queenCells = new List<Cell>();	// if player has promoted one or more pawns to queens

		// go through each piece belonging to the player of the current turn
		foreach (string key in playerPieces.Keys) {
		Piece p;
		// if piece is queen or king, store the cell it is located in
			if (playerPieces.TryGetValue (key, out p)) {
				if (p is King) {
					kingCell = p.GetComponentInParent<Cell> ();
				} else if(p is Queen) {
					queenCells.Add(p.GetComponentInParent<Cell> ());
				}
			}
		}


	}
}