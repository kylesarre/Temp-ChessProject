using UnityEngine;
using System.Collections;
/****************************************************************************************/
/*
/* FILE NAME: Highlighter
/*
/* DESCRIPTION: This is a utility class of the board controller for highlighting game objects. 
/* It includes methods that modify the stack of the highlightable component of a gameobject
/*
 * AUTHOR: Kyle Sarre
 * 
/* Dependency: Requires a highlightable component on any gameObjects being modified
/*
/****************************************************************************************/
public class Highlighter : MonoBehaviour 
{
	// stores previous collisions and current collisions across all layers of the game
	private RaycastHit2D[,] collisionTable;

	// Use this for initialization
	void Start () 
	{
		int Layers = 32;
		int collisions = 2;
		collisionTable = new RaycastHit2D[Layers,collisions];
	}
	
	// Update is called once per frame
	void Update () 
	{		
	}
	// adds a new highlight color to a gameObject's hightlightable stack
	// @param Gameobject gameobject - the gameobject we wish to highlight
	// @param Color col - the color we wish to highlight an object
	public void AddHighlight(GameObject gameObject, Color col)
	{
		if (gameObject.GetComponent<Highlightable> ()) 
		{
			Highlightable highlightable = gameObject.GetComponent<Highlightable> ();
			if (col == Color.green) 
			{
				col.g = col.g + highlightable.Tint;
			} 
			else if (col == Color.blue) 
			{
				col.b = col.b + highlightable.Tint;
			}
			highlightable.colorHistory.Push (col);
		} 
		else
			return;
	}

	// removes a highlight color from a gameObject's highlightable stack and stores it
	// @param Gameobject gameObject - the gameobject whose highlight we wish to remove
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
	// if the cursor is touching the same object from the previous frame, nothing occurs
	// if the cursor is not touching the same object from the previous frame and is not currently touching any object, it calls removeHighlight() on the previous object.
	// if the cursor is not touching the same object from the previous frame but is touching a new object in the current frame, it calls addHighlight() on the new object
	// @params: layer1 - the layer(an attribute of all game obejcts) we want raycasts to specifically collide with, 
	// @param: col - the highlight color we wish to use
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
			// update collisions : previousCollision = newCollision
			collisionTable [layer1, 1] = collisionTable [layer1, 0];
		}
	}
	// highlights the cells inside the visitable cells list of a piece green
	// @param the piece whose visitable cells list we wish to highlight
	public void HighlightVisitableCells(GameObject piece)
	{
		Piece piece_script = piece.GetComponent<Piece> ();
		foreach (Cell visitableCell in piece_script.VisitableCells) 
		{
			AddHighlight(visitableCell.gameObject, Color.green);
		}
	}
	// removes all highlights from the cells in a piece's visitable cells list
	// @param the piece whose visitable cells list highlights we wish to undo.
	public void UndoHighlightVisitableCells(GameObject piece)
	{
		Piece piece_script = piece.GetComponent<Piece> ();
		foreach (Cell visitableCell in piece_script.VisitableCells) 
		{
			RemoveHighlight(visitableCell.gameObject);
		}
	}
}