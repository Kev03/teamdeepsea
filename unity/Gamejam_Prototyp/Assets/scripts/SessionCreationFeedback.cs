using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SessionCreationFeedback
{
    public int session_id;

    public int SessionID
    {
        get { return session_id; }
    }
}
