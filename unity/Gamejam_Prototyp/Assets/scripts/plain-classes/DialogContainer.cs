using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogContainer
{

    private string[] dialogParts;
    public string[] DialogParts
    {
        get { return dialogParts; }
        set { dialogParts = value; }
    }

    private AudioClip[] audioClips;
    public AudioClip[] AudioClips
    {
        get { return audioClips; }
        set { audioClips = value; }
    }

}
