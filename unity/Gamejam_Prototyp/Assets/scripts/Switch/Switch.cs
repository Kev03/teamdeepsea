using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    public UnityEvent OnDiverClicked;
    public UnityEvent<Switch> OnDiverClickedObject;

    private Sprite startTexture;

    private void Start()
    {
        startTexture = GetComponent<SpriteRenderer>().sprite;
    }



    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Movement>()!=null)
        {
            OnDiverClicked?.Invoke();
            OnDiverClickedObject?.Invoke(this);
            GetComponent<BoxCollider2D>().enabled = false;
        }

    }

    public void Reset()
    {
        GetComponent<SpriteRenderer>().sprite = startTexture;
        GetComponent<BoxCollider2D>().enabled = true;
    }

}
