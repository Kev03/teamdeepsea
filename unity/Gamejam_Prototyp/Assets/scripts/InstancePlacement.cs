using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancePlacement : MonoBehaviour
{

    public void AddChild(GameObject gameObject)
    {
        gameObject.transform.parent = this.transform;
    }

}
