/****************************************************************************************/
/*
/* FILE NAME: LoadOnClick.cs
/*
/* DESCRIPTION: Loads a scene from a button click.
/*
/* REFERENCE:
/*
/*   DATE          BY         CHANGE REF  DESCRIPTION
/* ======== ================ =========== ==============================================
/* 11/26/16 Hanna Cunningham             wrote script and linked the main menu and game
/* 
/*
/*
/*
/****************************************************************************************/

using UnityEngine;

public class LoadOnClick : MonoBehaviour
{
    /**
     * loads a scene 
     */
    public void LoadScene(int scene)
    {
        Application.LoadLevel(scene);
    }
}
