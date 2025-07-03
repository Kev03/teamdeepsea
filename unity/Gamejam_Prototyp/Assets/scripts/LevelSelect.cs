using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelSelect : MonoBehaviour
{

    public UnityEvent<int> OnSelectionChanged;

    public int[] levelsAvail;

    private int currentPos = 0;

    private void Start()
    {
        OnSelectionChanged?.Invoke(levelsAvail[currentPos]);
    }

    public void SelectionChange(int direction)
    {
        currentPos = (currentPos + direction) % levelsAvail.Length;
        currentPos = currentPos < 0 ? levelsAvail.Length - 1 : currentPos;
        OnSelectionChanged?.Invoke(levelsAvail[currentPos]);
    }
 
}
