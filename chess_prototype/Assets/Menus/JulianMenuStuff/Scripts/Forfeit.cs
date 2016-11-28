using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Forfeit : MonoBehaviour {
    public GameObject forfeitPopUp;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ForfeitFunc(bool yes)
    {
        if (yes)
            SceneManager.LoadScene(0);
        else
            forfeitPopUp.SetActive(false);
    }
}
