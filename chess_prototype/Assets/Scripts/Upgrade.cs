using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Upgrade : MonoBehaviour
{
	public int energyCost;

	protected BoardController boardController = GameController.gameController.boardController.GetComponent<BoardController>();
	protected PlayerController playerController = GameController.gameController.playerController.GetComponent<PlayerController>();

	public virtual void ApplyUpgrade() {}

	public virtual void RemoveUpgrade() {}

	public int EnergyCost {
		get { return energyCost; } 
	}

	public bool SpendEnergy () {
		if (playerController.WhoseTurn ().Energy >= energyCost) {
			playerController.EnergyDecrease (energyCost);
			return true;
		}
		else
			return false;
	}
}