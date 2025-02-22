using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObjectsMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform[] route;

    private Vector3 target;
    private int targetPos = 0;


    private void Start()
    {
        target = route[0].position;
    }

    void Update()
    {
        // Move our position a step closer to the target.
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, target) < 0.001f)
        {
            NextTarget();
        }

    }

    private void NextTarget()
    {
        targetPos = (targetPos + 1) % (route.Length);
        target = route[targetPos].position;

    }




}
