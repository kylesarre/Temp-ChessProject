using UnityEngine;
using System.Collections;
public class Pawn : Piece
{
	public PawnState currentState;
	public enum PawnState
	{
		NeverMoved, Moved
	}
	// awake occurs before start
	void Awake()
	{		
		currentState = PawnState.NeverMoved;
		// ensures that we can set this Piece's isWhite field before trying to access it Do_Init()
		enabled = false;
	}
	// Use this for initialization
	void Start () 
	{
		//Debug.Log (IsWhite);
		base.Do_Init();
		Sprite temp = null;
		if (!isWhite) 
		{
			movementVectors.Add (new Vector3 (0, 1, 0));
			gameObject.GetComponent<SpriteRenderer> ().sprite = GetComponentInParent<SpriteDictionary> ().SpriteDict["spr_chess_pieces_0"];
		} 
		if(isWhite)
		{
			movementVectors.Add (new Vector3 (0, -1, 0));
			gameObject.GetComponent<SpriteRenderer> ().sprite	= GetComponentInParent<SpriteDictionary>().SpriteDict["spr_chess_pieces_6"];
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}		

}
