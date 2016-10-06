using UnityEngine;
using System.Collections;

public class HightlightObject : MonoBehaviour 
{
	private Color startColor;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter()
	{
		startColor = GetComponent<SpriteRenderer> ().material.color;
		GetComponent<SpriteRenderer> ().material.color = Color.yellow;
	}
	void OnMouseExit()
	{
		GetComponent<SpriteRenderer> ().material.color = startColor;
	}
}
	
