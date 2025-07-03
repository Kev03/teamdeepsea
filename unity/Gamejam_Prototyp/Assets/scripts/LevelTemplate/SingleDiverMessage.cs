using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SingleDiverMessage
{

    [Serializable]
    public enum DiverMessageTypes
    {
        up, down, left, right, wait
    }

    public DiverMessageTypes message;

    public SingleDiverMessage(DiverMessageTypes message)
    {
        this.message = message;
    }

}
