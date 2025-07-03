using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SessionJoinFeedback 
{

    public string feedback;

    public string Feedback
    {
        get { return feedback; }
    }

    public int levelJoined;

    public int LevelJoined
    {
        get { return levelJoined; }
    }

    public override string ToString()
    {
        return feedback + ", " + levelJoined;
    }

}
