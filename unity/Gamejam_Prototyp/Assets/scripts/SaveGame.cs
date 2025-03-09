using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame
{
    
    [SerializeField]
    private bool introPlayed = false;
    public bool IntroPlayed
    {
        get { return introPlayed; }
        set { introPlayed = value; }
    }

    public SaveGame()
    {
        introPlayed = false;
    }


}
