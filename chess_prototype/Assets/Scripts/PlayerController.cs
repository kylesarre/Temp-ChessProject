using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	playerColors activeColor;

	public enum playerColors
	{
		white, black
	}


	// Use this for initialization
	void Start () 
	{
		activeColor = playerColors.white;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
