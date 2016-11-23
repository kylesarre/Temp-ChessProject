using UnityEngine;
using System.Collections;

public class King : Piece 
{
	void Awake()
	{
		base.Do_Init();
		Vector3[] vectors = { new Vector3 (1, 1, 0), new Vector3 (-1, 1, 0), new Vector3 (-1, -1, 0), new Vector3 (1, -1, 0),
			new Vector3 (1, 0, 0), new Vector3 (-1, 0, 0), new Vector3 (0, 1, 0), new Vector3 (0, -1, 0) };
		movementVectors.AddRange (vectors);
		enabled = false;
	}
	// Use this for initialization
	void Start () 
	{
		
		if (!isWhite) 
		{			
			gameObject.GetComponent<SpriteRenderer> ().sprite = GetComponentInParent<SpriteDictionary> ().SpriteDict["spr_chess_pieces_5"];
		} 
		if(isWhite)
		{
			gameObject.GetComponent<SpriteRenderer> ().sprite	= GetComponentInParent<SpriteDictionary>().SpriteDict["spr_chess_pieces_11"];
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
