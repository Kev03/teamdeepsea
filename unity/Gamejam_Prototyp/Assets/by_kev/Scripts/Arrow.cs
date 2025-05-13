using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private float speed;

    public void Init(Vector3 rotation, Vector3 position)
    {
        transform.eulerAngles = rotation;
        transform.position = position;
        GetComponent<Animation>().Play("arrow-fade");
    }

    public void AfterFadeout()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * speed);
    }



}
