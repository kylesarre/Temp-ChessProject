/****************************************************************************************/
/*
/* FILE NAME: QuitOnClick.cs
/*
/* DESCRIPTION: Allows the application to be exited from a button click.
/*
/* REFERENCE:
/*
/*   DATE          BY         CHANGE REF  DESCRIPTION
/* ======== ================ =========== ================================================
/* 11/26/16 Hanna Cunningham             created script and connected it to the main menu
/* 
/*
/*
/*
/****************************************************************************************/

using UnityEngine;

public class QuitOnClick : MonoBehaviour
{
    /**
     * exits the game and closes the executable
     */    
    public void QuitApplication()
    {
        Application.Quit();
    }
}
