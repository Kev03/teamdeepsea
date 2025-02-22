using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiverAudioPlayer : MonoBehaviour
{

    [SerializeField, Tooltip("Audiofiles. Please keep them in order with the file-ids array.")]
    private AudioClip[] audiofiles;

    [SerializeField, Tooltip("Audiofile ids. Please keep them in order with the Audiofiles array.")]
    private string[] audiofileIDs;

    public void OnAudioInput(string id)
    {
        //Debug.Log(id);
        int index = System.Array.IndexOf(audiofileIDs, id);
        
        //Debug.Log(audiofiles[index]);
        GetComponent<AudioSource>().PlayOneShot(audiofiles[index]);
    }

}
