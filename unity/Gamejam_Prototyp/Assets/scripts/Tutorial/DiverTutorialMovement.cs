using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiverTutorialMovement : MonoBehaviour
{

    private Vector3 destination;

    [SerializeField]
    private float speed = 1.0f;

    [SerializeField]
    private float stepRange = 10.0f;

    private void Start()
    {
        destination = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    }

    public void ChangeDestination(Vector3 direction)
    {
        destination += stepRange*direction;
    }
}
