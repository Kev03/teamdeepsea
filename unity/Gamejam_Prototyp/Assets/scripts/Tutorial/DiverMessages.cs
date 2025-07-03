using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DiverMessages : MonoBehaviour
{
    public UnityEvent<Vector3> destinationChange;

    public void ChangeDesination(string destination)
    {
        Vector3 desinationChangeVector = Vector3.zero;
        switch (destination.ToLower())
        {
            case "up": { desinationChangeVector.y = 1; break; }
            case "down": { desinationChangeVector.y = -1; break; }
            case "left": { desinationChangeVector.x = -1; break; }
            case "right": { desinationChangeVector.x = 1; break; }
            default: { Debug.Log("Some wrong destination was communicated to DiverMessages."); break; }
        }

        destinationChange?.Invoke(desinationChangeVector);
    }

}
