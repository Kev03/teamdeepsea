using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestruction : MonoBehaviour
{

    [SerializeField]
    private bool onAwake = false;

    private void Awake()
    {
        if (onAwake)
        {
            DestructionRequest();
        }
        
    }

    public void DestructionRequest()
    {
        Destroy(this.gameObject);
    }

}
