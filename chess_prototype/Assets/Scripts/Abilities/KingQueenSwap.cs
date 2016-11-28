using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KingQueenSwap : Upgrade
{
	int energyCost = 15;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}

	// TODO FINISH THIS
//	public override void ApplyUpgrade ()
//	{
//	if (!SpendEnergy())
//		return;
//
//	Dictionary<string, Piece> playerPieces = boardController.PlayerTurn.MyPieces;
//
//	Cell kingCell;
//	Cell[] queenCell = new Cell[9];
//
//	// go through each piece belonging to the player of the current turn
//	foreach (string key in playerPieces.Keys) {
//		Piece p;
//		// if piece is bishop, add one square sideways and backwards to its movement vectors
//		if (playerPieces.TryGetValue (key, out p)) {
//			if (p is King) {
//
//			}
//		}
//	}
}