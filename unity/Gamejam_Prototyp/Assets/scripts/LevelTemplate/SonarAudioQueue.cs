using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarAudioQueue : MonoBehaviour
{

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip collectableSound;

    public void OnSignallingTime(List<GameObject> newCollectables)
    {
        Queue<GameObject> collectablesInSight = new Queue<GameObject>(newCollectables);
        StartCoroutine(PlayRoutine(collectablesInSight));
        
    }

    IEnumerator PlayRoutine(Queue<GameObject> queuedObjects)
    {
        while (queuedObjects.Count > 0)
        {
            GameObject collectabe = queuedObjects.Dequeue();
            float distance = Vector3.Distance(transform.position, collectabe.transform.position);
            float volume = GetVolume(distance);

            audioSource.volume = volume;
            audioSource.PlayOneShot(collectableSound);
            
            yield return new WaitForSeconds(0.7f);
        }
    }

    private float GetVolume(float distance)
    {
        return 1.0f - distance / 200.0f;
    }


}
