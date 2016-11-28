using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnergyScript : MonoBehaviour
{
    public Text amountText;
    
    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
       amountText.text = "" + GameController.gameController.playerController.GetComponent<PlayerController>().WhoseTurn().Energy;
	}
}
