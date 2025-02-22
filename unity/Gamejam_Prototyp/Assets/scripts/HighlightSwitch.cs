using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightSwitch : MonoBehaviour
{
    [SerializeField]
    private GameObject[] highlightObjects;

    private int currentPos = 0;

    public void HightlightNext()
    {
        highlightObjects[currentPos].SetActive(false);
        currentPos = (currentPos + 1) % highlightObjects.Length;
        highlightObjects[currentPos].SetActive(true);
    }





}
