using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WhoseTurnScript : MonoBehaviour
{
    public string[] playerNames = new string[2];
    public Text displayName;
    public bool isWhiteTurn = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isWhiteTurn)
            displayName.text = playerNames[0] + "'s turn";
        else
            displayName.text = playerNames[1] + "'s turn";
	}

    public void addName(string name)
    {
        playerNames[playerNames.Length] = name;
    }
}
