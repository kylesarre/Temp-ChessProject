using UnityEngine;
using System.Collections;

public class GameDialogueChoices : MonoBehaviour {

    public GameObject GameDiaMenu;
    public GameObject OptionsMenu;
    public GameObject HelpMenu;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Resume()
    {
        GameDiaMenu.SetActive(false);
    }

    public void Options()
    {
        OptionsMenu.SetActive(true);
    }

    public void Help()
    {
        HelpMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
    
}
