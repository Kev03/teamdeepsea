using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

public class SubmarineLight : MonoBehaviour
{
    public UnityEvent<bool> OnToggling;

    public void Toggle()
    {
        GetComponent<Light2D>().enabled = !GetComponent<Light2D>().enabled;
        GetComponent<SpriteMask>().enabled = !GetComponent<SpriteMask>().enabled;
        GetComponent<PolygonCollider2D>().enabled = !GetComponent<PolygonCollider2D>().enabled;
        
        OnToggling?.Invoke(GetComponent<Light2D>().enabled);
    }

    public void SetEnabledState(bool value)
    {
        GetComponent<Light2D>().enabled = value;
        GetComponent<SpriteMask>().enabled = value;
        GetComponent<PolygonCollider2D>().enabled = value;
    }


}