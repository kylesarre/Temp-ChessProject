using UnityEngine;
using System.Collections.Generic;

/****************************************************************************************/
/*
/* FILE NAME: Highlightable
/*
/* DESCRIPTION: This component is used by all gameObjects in the system that can be highlighted.
/* It stores a history of all highlights currently on the object, starting with the default color of the sprite(its original state)
/* REFERENCE:
/*
/* DATE BY CHANGE REF DESCRIPTION
/* ======== ======= =========== =============
/* 
/* 
/*
/*
/*
/****************************************************************************************/

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
	// called once per frame
	void Update()
	{
		updateHighlight ();
	}
	// the tint of the material color of this game object
	public float Tint
	{
		set { this.tint = value; }
	}
	// takes a peek at the top of the stack for this highlightable and assigns the gameobject material color to the color retrieved from the stack.
	private void updateHighlight()
	{
		if (colorHistory != null && colorHistory.Count != 0)
		{
			currentColor = colorHistory.Peek ();
			GetComponent<SpriteRenderer> ().material.color = currentColor;
		}
	}
}
