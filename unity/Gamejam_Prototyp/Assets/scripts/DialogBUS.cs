using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBUS : MonoBehaviour
{

    [SerializeField]
    private TextDialog dialogContent;

    [SerializeField]
    private TextDialog dialogPlayer;

    public void PassData()
    {
        DialogContainer dialogContainer = new();
        dialogContainer.DialogParts = dialogContent.DialogParts;
        dialogContainer.AudioClips = dialogContent.AudioClips;
        
        dialogPlayer.OnDialogEnd.AddListener(dialogContent.DialogPlayed);
        dialogPlayer.OnNewDialogPart.AddListener(dialogContent.DialogPartPlayed);
        
        dialogPlayer.SetNewDialog(dialogContainer);
    }

}
