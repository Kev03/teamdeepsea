using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiverCollector : MonoBehaviour
{

    [SerializeField]
    private AudioSource sonar;

    private AudioClip collectionSFX; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sonar.PlayOneShot(collectionSFX);
    }

}
