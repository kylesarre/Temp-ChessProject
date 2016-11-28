using UnityEngine;
using System.Collections;

public class PowerUpMenuController : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject ForfeitMenu;

    public void Settings()
    {
        settingsMenu.SetActive(true);
    }

    public void Forfeit()
    {
        ForfeitMenu.SetActive(true);
    }





}
