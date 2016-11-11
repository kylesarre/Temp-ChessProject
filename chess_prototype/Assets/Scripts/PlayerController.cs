using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public GameObject obj_Player;
	public GameObject player1;
	public GameObject player2;

	public Player player1_scr;
	public Player player2_scr;

	// Use this for initialization
	void Start () 
	{
		player1 = (GameObject)Instantiate (obj_Player,new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
		player2 = (GameObject)Instantiate (obj_Player,new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);

		player1_scr = player1.GetComponent<Player> ();
		player2_scr = player2.GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void assignName(Player player, string name)
	{
		player.PlayerName = name;
	}
	public Player assignRandomColor()
	{
		int randomInt = Random.Range (0, 2);
		if (randomInt == 0) 
		{
			player1_scr.IsWhite = true;
			player2_scr.IsWhite = false;
			return player1_scr;
		}
		else
		{
			player1_scr.IsWhite = false;
			player2_scr.IsWhite = true;
			return player2_scr;
		}
	}
}