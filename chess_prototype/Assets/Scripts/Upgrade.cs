using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Upgrade : MonoBehaviour
{
	public int energyCost;

	public void ApplyUpgrade() {}

	public void RemoveUpgrade() {}

	public int EnergyCost
	{
		get { return energyCost; } 
	}
}