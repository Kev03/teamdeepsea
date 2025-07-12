using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnglerFish : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
        Debug.Log(startPosition);
        this.enabled = false;
    }

    private void Update()
    {
        if (Submarine.Instance != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, Submarine.Instance.transform.position, step);
        }
    }

    public void Reset()
    {
        transform.position = startPosition;
        enabled = false;
    }


}
