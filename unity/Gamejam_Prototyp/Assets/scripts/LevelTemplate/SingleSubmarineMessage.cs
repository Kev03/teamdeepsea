using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SingleSubmarineMessage
{
    [Serializable]
    public enum SubmarineMessageTypes
    {
        up, down, left, right, collect
    }

    public SubmarineMessageTypes message;

    public SingleSubmarineMessage(SubmarineMessageTypes message)
    {
        this.message = message;
    }
 
}
