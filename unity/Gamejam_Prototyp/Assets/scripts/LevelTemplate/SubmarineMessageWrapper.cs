using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class SubmarineMessageWrapper
{

    public Vector3 submarinePosition;
    public bool lightActive;
    public bool alignment;

    public SerializableList<SingleSubmarineMessage> messagesToDiver = new SerializableList<SingleSubmarineMessage>();

}
