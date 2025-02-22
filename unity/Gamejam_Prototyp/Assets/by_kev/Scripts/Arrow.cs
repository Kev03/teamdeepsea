using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{  
    public void Init(Vector3 rotation, Vector3 position)
    {
        Debug.Log(rotation);
        transform.eulerAngles = rotation;
        transform.position = position;
        GetComponent<Animation>().Play("arrow-fade");
    }

    public void AfterFadeout()
    {
        Destroy(gameObject);
    }



}
