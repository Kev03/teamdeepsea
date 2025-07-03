using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SerializableClamData
{

    public string id;

    public string ID
    {
        get { return id; }
        set { id = value; }
    }

    public bool collected = false;

    public bool Collected
    {
        get { return collected; }
        set { collected = value; }
    }

    public SerializableClamData(Collectable collectable)
    {
        ID = collectable.ID;
        collected = true;
    }
    
}
