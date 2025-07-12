using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MovingSyncdObjectWrapper
{

    public string id;

    public string ID
    {
        get { return id; }
        set { id = value; }
    }

    public Vector3 position;

    public Vector3 Position
    {
        get { return position; }
        set { position = value; }
    }

    public bool looksLeft;

    public bool LooksLeft
    {
        get { return looksLeft; }
        set { looksLeft = value; }
    }

}
