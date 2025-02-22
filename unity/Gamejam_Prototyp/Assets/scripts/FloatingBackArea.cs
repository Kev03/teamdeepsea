using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloatingBackArea : MonoBehaviour
{
    public UnityEvent OnAreaEntered;
    public UnityEvent OnAreaExited;

    [SerializeField]
    private Vector2 direction = Vector2.zero;

    [SerializeField]
    private float speed = 10.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<FloatingMovement>() != null)
        {
            collision.GetComponent<FloatingMovement>().Enable(speed, direction);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<FloatingMovement>() != null)
        {
            collision.GetComponent<FloatingMovement>().Disable();
        }
    }

}
