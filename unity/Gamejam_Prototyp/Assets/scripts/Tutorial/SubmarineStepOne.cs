using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SubmarineStepOne : TutorialStep
{

    public void IntroTextsDone()
    {
        OnStepFinished?.Invoke();
    }

}
