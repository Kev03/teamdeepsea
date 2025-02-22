using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class GatePrecondition : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent<GatePrecondition> OnPreconditionMet;

    public void PreconditionMet()
    {
        OnPreconditionMet?.Invoke(this);
    }

}
