using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Upgrade : MonoBehaviour
{
	public int energyCost;

	public BoardController boardController = GameController.gameController.boardController.GetComponent<BoardController>();
	public PlayerController playerController = GameController.gameController.playerController.GetComponent<PlayerController>();

	public virtual void ApplyUpgrade() {}

	public virtual void RemoveUpgrade() {}

	public int EnergyCost
	{
		get { return energyCost; } 
	}
}