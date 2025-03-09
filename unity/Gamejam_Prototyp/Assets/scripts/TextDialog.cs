using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TextDialog : MonoBehaviour
{
    public UnityEvent<DialogMessage> OnNewDialogPart;
    public UnityEvent OnDialogEnd;

    [SerializeField]
    private string[] dialogParts;
    public string[] DialogParts
    {
        get { return dialogParts; }
    }

    [SerializeField]
    private AudioClip[] audioClips;
    public AudioClip[] AudioClips
    {
        get { return audioClips; }
    }

    private int currentPosition = 0;

    public void ShowText()
    {
     
        if (currentPosition < dialogParts.Length)
        {
            DialogMessage dialogMessage = new DialogMessage(dialogParts[currentPosition], currentPosition, audioClips[currentPosition]);
            OnNewDialogPart.Invoke(dialogMessage);
            currentPosition = currentPosition + 1;
        }
        else
        {
            OnDialogEnd?.Invoke();
        }
        
    }

    private void OnEnable()
    {
        //currentPosition = 0;
    }

    public void SetNewDialog(DialogContainer dialogContainer)
    {
        this.dialogParts = dialogContainer.DialogParts;
        this.audioClips = dialogContainer.AudioClips;
        currentPosition = 0;
        ShowText();
    }

    public void DialogPlayed()
    {
        OnDialogEnd?.Invoke();
    }

    public void DialogPartPlayed(DialogMessage dialogMessage)
    {
        //Debug.Log("Received Message");
        OnNewDialogPart?.Invoke(dialogMessage);
    }

}
