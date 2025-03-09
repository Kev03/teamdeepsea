using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector : MonoBehaviour
{
    public UnityEvent OnCollisionEnter;
    public UnityEvent OnCollisionExit;

    [SerializeField]
    private string collisionObjectName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collisionObjectName == "" || collisionObjectName == collision.gameObject.name)
        {
            OnCollisionEnter?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collisionObjectName == "" || collisionObjectName == collision.gameObject.name)
        {
            OnCollisionExit?.Invoke();
        }
    }


}
