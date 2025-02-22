using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radar : MonoBehaviour
{
    private AudioSource radarAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        radarAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
          if (Input.GetKeyDown(KeyCode.Space)) // KeyCode.Space kann durch jede beliebige Taste ersetzt werden
        {
            // Sound abspielen, wenn die Taste gedrückt wird
            if (radarAudioSource != null)
            {
                radarAudioSource.Play();
            }
        }
    }
    
}
