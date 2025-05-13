using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SubmarineLight : MonoBehaviour
{

    public void Toggle()
    {
        GetComponent<Light2D>().enabled = !GetComponent<Light2D>().enabled;
        GetComponent<SpriteMask>().enabled = !GetComponent<SpriteMask>().enabled;
        GetComponent<PolygonCollider2D>().enabled = !GetComponent<PolygonCollider2D>().enabled;
    }

}
