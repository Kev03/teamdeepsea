using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioDialog : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    private void PlayClip(AudioClip audioClip)
    {
        if (audioClip != null) {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }

    public void ReceiveDialogMessage(DialogMessage dialogMessage)
    {
        PlayClip(dialogMessage.AssignedAudioClip);
    }

}
