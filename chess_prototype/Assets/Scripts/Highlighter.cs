using UnityEngine;
using System.Collections;

public class Highlighter : MonoBehaviour 
{
	private RaycastHit2D[,] collisionTable;
	private BoardController boardController;
	// Use this for initialization
	void Start () 
	{
		int Layers = 32;
		int collisions = 2;
		collisionTable = new RaycastHit2D[Layers,collisions];
		boardController = this.gameObject.GetComponent<BoardController> ();
	}
	
	// Update is called once per frame
	void Update () 
	{		
	}
	// adds a new highlight color to a gameObject's hightlightable stack
	public void AddHighlight(GameObject gameObject, Color col)
	{
		if (gameObject.GetComponent<Highlightable> ()) 
		{
			Highlightable highlightable = gameObject.GetComponent<Highlightable> ();
			highlightable.colorHistory.Push (col);
		} 
		else
			return;
	}

	// removes a highlight color from a gameObject's highlightable stack and stores it
	public void RemoveHighlight(GameObject gameObject)
	{
		if (gameObject.GetComponent<Highlightable> ()) 
		{
			Highlightable highlightable = gameObject.GetComponent<Highlightable> ();
			highlightable.prevColor = highlightable.colorHistory.Pop ();
		} 
		else
			return;
	}
	// calls Highlight() whenever the cursor touches a gameObject on the specified layer.
	// if the cursor is touching the same object, no calls are made.
	// if the cursor is no longer touching the object, it calls removeHighlight() on the object.
	// if the cursor is touching a new object, it calls addHighlight() on the new object
	// params: layer1 - the layer we want raycast to pay attention to, col - the color we wish to highlight the objects on this layer with.
	public void UpdateHighlightableOnMouseCollision(int layer1, Color col)
	{
		// ensure that the input to this function is in a valid range. Layers = [0,31]
		if (layer1 < 0 || layer1 > 31) 
		{
			Debug.LogException (new System.ArgumentOutOfRangeException("Error highlighting on layer: "+layer1+". The layer specified is outside of a valid range."));
			return;
		} 
		else 
		{
			// calculate a vector from camera position to mouse position and store it
			Vector2 camPos = (Vector2)Camera.main.ScreenToWorldPoint (Input.mousePosition);
			// set up a layer mask for the given layer (Phsyics2D.Raycast requires a mask of the specified layer to target that layer)
			int layerMask1 = 1 << layer1;
			// see if a collision has occurred and store it in the table column for newCollision
			collisionTable [layer1, 0] = Physics2D.Raycast (camPos, Vector2.zero, Mathf.Infinity, layerMask1);
			if (collisionTable [layer1, 0].collider != null) 
			{
				// we hit something on layer1
				Highlightable highlightable = collisionTable [layer1, 0].collider.gameObject.GetComponent<Highlightable> ();

				if ( highlightable != null && !collisionTable[layer1, 0].collider.Equals(collisionTable[layer1, 1].collider) ) 
				{
					// we have a hightlightable and we havn't collided with something previously
					AddHighlight (collisionTable [layer1, 0].collider.gameObject,col);
				}
				if (collisionTable [layer1, 1].collider != null
				    && collisionTable [layer1, 1].collider.GetComponent<Highlightable> ()
				    && !collisionTable [layer1, 1].collider.Equals (collisionTable [layer1, 0].collider)) 
				{
					// we have collided with something previously, and it had a highlightable, and we are colliding with something new
					RemoveHighlight (collisionTable [layer1, 1].collider.gameObject);
				}
			} 
			else if (collisionTable [layer1, 1].collider != null 
				&& collisionTable [layer1, 1].collider.gameObject.GetComponent<Highlightable> () != null) 
			{
				//we have collided with something previously, and it had a hightlightable, but we are not colliding with anything anymore
				RemoveHighlight (collisionTable [layer1, 1].collider.gameObject);
			}
			// previousCollision = newCollision
			collisionTable [layer1, 1] = collisionTable [layer1, 0];
		}
	}
	public void HighlightVisitableCells(GameObject piece)
	{
		Piece piece_script = piece.GetComponent<Piece> ();
		foreach (Cell visitableCell in piece_script.ValidCells) 
		{
			AddHighlight(visitableCell.gameObject, Color.green);
		}
	}
	public void UndoHighlightVisitableCells(GameObject piece)
	{
		Piece piece_script = piece.GetComponent<Piece> ();
		foreach (Cell visitableCell in piece_script.ValidCells) 
		{
			RemoveHighlight(visitableCell.gameObject);
		}
	}
}