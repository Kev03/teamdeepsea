using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PinPad : MonoBehaviour
{
    public UnityEvent<string> OnInputChange;

    private string currentInput;

    public void AddInput(string input)
    {
        currentInput += input;
        OnInputChange?.Invoke(currentInput);
    }

    public void RemoveLast()
    {
        if(currentInput.Length > 0)
        {
            currentInput = currentInput.Substring(0, currentInput.Length - 1);
            OnInputChange?.Invoke(currentInput);
        }
        
    }

    public void Clear()
    {
        currentInput = "";
        OnInputChange?.Invoke(currentInput);
    }


}
