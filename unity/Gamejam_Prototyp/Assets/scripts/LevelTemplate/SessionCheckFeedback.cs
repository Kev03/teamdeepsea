using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SessionCheckFeedback
{

    public string feedback;

    public string Feedback
    {
        get { return feedback; }
        set { feedback = value; }
    }

    public string submarineMsg;

    public string SubmarineMsg
    {
        get { return submarineMsg; }
        set { submarineMsg = value; }
    }

    public string diverMsg;

    public string DiverMsg
    {
        get { return diverMsg;}
        set { diverMsg = value; }
    }

    public SerializableList<string> clamDataToUpdate = new SerializableList<string>();

    public SubmarineMessageWrapper GetSubmarineMessage() {
        SubmarineMessageWrapper message = JsonUtility.FromJson<SubmarineMessageWrapper>(submarineMsg);
        return message;
    }

    public DiverMessageWrapper GetDiverMessage()
    {
        DiverMessageWrapper message = JsonUtility.FromJson<DiverMessageWrapper>(diverMsg);
        return message;
    }

}
