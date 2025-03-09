using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampToggle : MonoBehaviour
{
    [SerializeField]
    private GameObject flashLight;

    public void Toggle()
    {
        flashLight.gameObject.SetActive(!flashLight.gameObject.activeInHierarchy);
    }


}
