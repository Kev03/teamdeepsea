using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogMessage
{
    private string dialogText;
    public string DialogText
    {
        get
        {
            return dialogText;
        }
    }

    private int position;

    public int Position
    {
        get { return position; }
    }

    private AudioClip assignedAudioClip;

    public AudioClip AssignedAudioClip
    {
        get { return assignedAudioClip; }
    }

    public DialogMessage(string dialogText, int position, AudioClip assignedAudioClip)
    {
        this.dialogText = dialogText;
        this.position = position;
        this.assignedAudioClip = assignedAudioClip;
    }

}
