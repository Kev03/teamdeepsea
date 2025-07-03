using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SerializableList<T>
{
    public List<T> list = new List<T>();
    public long timestamp;

    public SerializableList()
    {
        ResetList();
    }

    public void ResetList()
    {
        list.Clear();
        timestamp = DateTime.Now.ToFileTimeUtc();
    }

}
