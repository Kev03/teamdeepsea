using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SubmarineStepThree : TutorialStep
{

    public void ClamReached()
    {
        OnStepFinished?.Invoke();
    }

}
