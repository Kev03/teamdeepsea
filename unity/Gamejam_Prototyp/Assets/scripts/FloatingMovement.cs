using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingMovement : MonoBehaviour
{
    [SerializeField]
    private Movement movement;

    private float speed = 0.0f;
    private Vector2 direction = Vector2.zero;

    public void Enable(float speed, Vector2 direction)
    {
        this.speed = speed;
        this.direction = direction;
        movement.enabled = false;
        this.enabled = true;
    }

    public void Disable()
    {
        this.speed = 0;
        this.direction = Vector2.zero;
        movement.enabled = true;
        this.enabled = false;
    }

    private void Update()
    {
        transform.position += Time.deltaTime * speed * new Vector3(direction.x, direction.y, 0);
    }

}
