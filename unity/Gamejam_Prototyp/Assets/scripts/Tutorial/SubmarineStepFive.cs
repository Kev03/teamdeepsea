using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SubmarineStepFive : TutorialStep
{

    public void ClamCollected()
    {
        OnStepFinished?.Invoke();
    }

}
