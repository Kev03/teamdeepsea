using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieCollision : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemie>() != null)
        {
            LastPortback.Instance.PortBack();
            collision.gameObject.GetComponent<Enemie>().ResetEnemie();
        }
    }

}