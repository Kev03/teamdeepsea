using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private AudioSource audioSource;
    public int audiodelay = 10;

    void Start()
    {
        // Referenz zur AudioSource-Komponente bekommen
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Prüfen, ob die gewünschte Taste gedrückt wird (z.B. die Leertaste)
        if (Input.GetKeyDown(KeyCode.Space)) // KeyCode.Space kann durch jede beliebige Taste ersetzt werden
        {
            PlayCollectibleSound();
        }
        
    }

    public void PlayCollectibleSound()
    {
        float audiodelay = CalculateAudioDelay();
        // Sound abspielen, wenn die Taste gedrückt wird
        if (audioSource != null)
        {
            audioSource.PlayDelayed(audiodelay);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Trigger entered by: " + other.gameObject.name);
        Destroy(gameObject);
    }
     private float CalculateAudioDelay()
    {
        // Finde den AudioListener in der Szene
        AudioListener audioListener = FindObjectOfType<AudioListener>();

        // Berechne die Entfernung zwischen diesem Objekt und dem AudioListener
        if (audioListener != null)
        {
            float distance = Vector2.Distance(audioListener.transform.position, transform.position);

            // Hier kannst du eine Formel anwenden, um zu bestimmen, wie die Verzögerung mit der Distanz skaliert werden soll
            // Zum Beispiel: 1 Sekunde Verzögerung pro 10 Einheiten Entfernung
            float delay = distance / audiodelay;

            return delay;
        }

        return 0f;
    }
}
