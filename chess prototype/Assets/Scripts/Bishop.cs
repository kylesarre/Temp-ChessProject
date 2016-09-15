using UnityEngine;
using System.Collections;

public class Bishop : Piece 
{

	// Use this for initialization
	void Start () 
	{
		Vector3[] vectors = { new Vector3 (1, 1, 0), new Vector3 (-1, 1, 0), new Vector3 (-1, -1, 0), new Vector3 (1, -1, 0) };
		movementVectors.AddRange (vectors);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
