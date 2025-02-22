using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OrderedSwitch : GatePrecondition
{

    public UnityEvent OnFalseAttempt;

    [SerializeField]
    private List<Switch> requiredSwitchOrder = new List<Switch>();

    private List<Switch> guessedSwitchOrder = new List<Switch>();

    private void Start()
    {
        foreach(Switch gameplaySwitch in requiredSwitchOrder){
            gameplaySwitch.OnDiverClickedObject.AddListener(SwitchClicked);
        }
    }

    private void SwitchClicked(Switch gameplaySwitch)
    {
        guessedSwitchOrder.Add(gameplaySwitch);
        if(requiredSwitchOrder.Count == guessedSwitchOrder.Count) { 
            CheckOrderMatch();
            if (CheckOrderMatch())
            {
                OnCorrectGuess();
            }
            else
            {
                OnFalseGuess();
            }
        }
    }

    private bool CheckOrderMatch()
    {
        bool orderIsCorrect = true;
        for(int i=0; i<requiredSwitchOrder.Count; i++)
        {
            orderIsCorrect &= (requiredSwitchOrder[i] == guessedSwitchOrder[i]);
        }
        return orderIsCorrect;
    }
       
    private void OnCorrectGuess()
    {
        Debug.Log("MEt");
        PreconditionMet();
    }

    private void OnFalseGuess()
    {
        foreach(Switch gameplaySwitch in requiredSwitchOrder)
        {
            gameplaySwitch.Reset();
        }

        OnFalseAttempt?.Invoke();
    }



}
