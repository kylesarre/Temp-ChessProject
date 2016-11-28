/****************************************************************************************/
/*
/* FILE NAME: saveOptions.cs
/*
/* DESCRIPTION: Connects the slider and main volume control to allow the volume of the game music to be changed in the options menu.
/*
/* REFERENCE:
/*
/*   DATE          BY         CHANGE REF  DESCRIPTION
/* ======== ================ =========== ================================
/* 11/28/16 Hanna Cunningham             created a working volume control
/* 
/*
/*
/*
/****************************************************************************************/

using UnityEngine;
using UnityEngine.UI;

public class saveOptions : MonoBehaviour
{
    public Slider volumeSlider;

    /**
     * adjusts volume when slider value is changed
     */
    public void OnValueChanged()
    {
        AudioListener.volume = volumeSlider.value;
    }

}
