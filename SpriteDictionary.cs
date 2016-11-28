using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SpriteDictionary : MonoBehaviour 
{
	private Dictionary<string, Sprite> spriteDict = new Dictionary<string, Sprite>();
	// Use this for initialization
	void Start () 
	{
		Sprite[] sprites = Resources.LoadAll<Sprite>("spr_chess_pieces");
		populateDict (sprites);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void populateDict(Sprite[] sprites)
	{
		foreach (Sprite sprite in sprites) 
		{
			spriteDict.Add (sprite.name, sprite);
		}
	}

	public Dictionary<string, Sprite> SpriteDict
	{
		get{ return spriteDict;}
	}
}
