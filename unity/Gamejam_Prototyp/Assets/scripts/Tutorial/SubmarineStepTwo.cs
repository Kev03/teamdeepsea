using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SubmarineStepTwo : TutorialStep
{

    private Dictionary<string, bool> buttonsClicked = new Dictionary<string, bool>()
    {
        {"Left", false},
        {"Right", false},
        {"Up", false},
        {"Down", false}
    };

    public void ButtonClicked(string button)
    {
        if (buttonsClicked.ContainsKey(button))
        {
            buttonsClicked[button] = true;
            if (IsSolved())
            {
                OnStepFinished?.Invoke();
            }

        }
    }

    private bool IsSolved()
    {
        bool solved = true;
        foreach(string key in buttonsClicked.Keys)
        {
            solved &= buttonsClicked[key];
        }
        return solved;
    }

}
