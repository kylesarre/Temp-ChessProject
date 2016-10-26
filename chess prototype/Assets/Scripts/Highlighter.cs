using UnityEngine;
using System.Collections;

public class Highlighter : MonoBehaviour 
{
	private Color startColor;
	public float tint;
	// Use this for initialization
	void Start () 
	{
		startColor = GetComponent<SpriteRenderer> ().material.color;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	// changes the material color of this gameObject
	public void Highlight(Color col)
	{
		GetComponent<SpriteRenderer> ().material.color = col*tint;
	}

	// restores default color of this gameObject
	public void UndoHighlight()
	{
		GetComponent<SpriteRenderer> ().material.color = startColor;
	}

}