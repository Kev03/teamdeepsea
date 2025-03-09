using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialWorkflow : MonoBehaviour
{
    public UnityEvent OnTutorialFinished;

    [SerializeField]
    private TutorialStep[] tutorialSteps;

    private int currentStep = 0;

    private void Start()
    {
        foreach(TutorialStep ts in tutorialSteps)
        {
            ts.OnStepFinished.AddListener(NextStep);
        }
    }

    private void NextStep()
    {
        tutorialSteps[currentStep].OnStepFinished.RemoveAllListeners();
        tutorialSteps[currentStep].gameObject.SetActive(false);
        currentStep++;
        if(currentStep < tutorialSteps.Length)
        {
            tutorialSteps[currentStep].gameObject.SetActive(true);
        }
        else
        {
            OnTutorialFinished?.Invoke();
        }
        
    }

    public void OnEnable()
    {
        currentStep = 0;
        tutorialSteps[currentStep].gameObject.SetActive(true);
    }

}
