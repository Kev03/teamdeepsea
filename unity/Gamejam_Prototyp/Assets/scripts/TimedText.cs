using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Timer))]
public class TimedText : MonoBehaviour
{
    public UnityEvent<string> OnNewText;
    public UnityEvent OnTextComplete;

    private string textToDisplay;

    private int currentPosition = 0;

    [SerializeField]
    private Timer timer;

    private void StartTextDisplay(string textToDisplay)
    {
        this.textToDisplay = textToDisplay;
        currentPosition = 0;
        timer.Run();
    }

    public void ReceiveDialogMessage(DialogMessage dialogMessage)
    {
        StartTextDisplay(dialogMessage.DialogText);
    }

    public void NextCharacter()
    {
        currentPosition += 1;
        OnNewText?.Invoke(textToDisplay.Substring(0, currentPosition));
        if(currentPosition >= textToDisplay.Length)
        {
            OnTextComplete?.Invoke();
            timer.Stop();
        }
        else
        {
            timer.Run();
        }
    }

}
