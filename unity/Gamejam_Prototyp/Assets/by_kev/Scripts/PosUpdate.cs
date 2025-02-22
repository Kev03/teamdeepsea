using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosUpdate : MonoBehaviour
{

    [SerializeField]
    private float offset = 10.0f;

    [SerializeField]
    private float speed = 10.0f;
    private Vector3 target;

    // Update is called once per frame
    void Update()
    {
        // Move our position a step closer to the target.
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, target) < 0.001f)
        {
            enabled = false;
        }

    }

    public void SetTarget(Vector3 target)
    {
        if(Vector3.Distance(transform.position, target) > offset)
        {
            //Debug.Log("Target SET");
            this.target = target;
            enabled = true;
        }
        



    }


}
