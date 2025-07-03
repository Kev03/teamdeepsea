using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SonarDetector : MonoBehaviour
{
    public UnityEvent<List<GameObject>> OnSignallingTime;

    private List<GameObject> collectablesInSight = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collectable>() != null)
        {
            collectablesInSight.Add(collision.gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Collectable>() != null)
        {
            collectablesInSight.Remove(collision.gameObject);
        }
    }

    public void SignallingTime()
    {
        OnSignallingTime?.Invoke(collectablesInSight);
    }


}
