using UnityEngine;
using System.Collections.Generic;

// This component is used by all gameObjects in the system that can be highlighted. 
// It stores a history of all highlights currently on the object, starting with the default color of the sprite(its original state)
// The Highlighter class modifies the data in this component.

public class Highlightable : MonoBehaviour 
{
	public Stack<Color> colorHistory;
	public Color currentColor;
	public Color prevColor;
	private float tint;

	// Use this for initialization
	void Start () 
	{
		// initialize colorHistory
		colorHistory = new Stack<Color> ();
		// add the sprite's original material color to the stack
		colorHistory.Push (GetComponent<SpriteRenderer> ().material.color);
	}	

	void Update()
	{
		updateHighlight ();
	}

	public float Tint
	{
		set { this.tint = value; }
	}

	private void updateHighlight()
	{
		if (colorHistory != null && colorHistory.Count != 0)
		{
			currentColor = colorHistory.Peek ();
			GetComponent<SpriteRenderer> ().material.color = currentColor;
		}
	}
}
