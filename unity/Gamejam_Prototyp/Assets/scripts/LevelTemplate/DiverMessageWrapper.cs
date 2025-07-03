using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class DiverMessageWrapper
{

    public Vector3 diverPosition;
    public bool alignment;

    public SerializableList<SingleDiverMessage> messagesToSubmarine = new SerializableList<SingleDiverMessage>();

}
