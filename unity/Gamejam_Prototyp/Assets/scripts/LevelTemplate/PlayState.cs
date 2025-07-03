using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayState
{

    public SubmarineMessageWrapper submarineMessageWrapper;

    public DiverMessageWrapper diverMessageWrapper;

    public SerializableList<string> clamDataToUpdate = new SerializableList<string>();

}
