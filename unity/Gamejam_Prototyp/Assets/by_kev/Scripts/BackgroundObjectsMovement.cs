using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObjectsMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform[] route;

    [SerializeField]
    private string id;

    public string ID
    {
        get { return id; }
    }

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

        transform.eulerAngles = target.x > transform.position.x ? new Vector3(0, 180, 0) : new Vector3(0, 0, 0);

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

    public MovingSyncdObjectWrapper GetWrapper()
    {
        MovingSyncdObjectWrapper wrapper = new MovingSyncdObjectWrapper();
        wrapper.ID = id;
        wrapper.Position = transform.position;
        wrapper.LooksLeft = transform.eulerAngles.y == 0;

        return wrapper;
    }

    public void Reposition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

}
