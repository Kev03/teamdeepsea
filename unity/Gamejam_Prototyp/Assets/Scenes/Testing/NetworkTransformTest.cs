using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkTransformTest : NetworkBehaviour
{
    [SerializeField]
    private Transform destination;

    [SerializeField]
    private float speed = 10.0f;

    private void Update()
    {
        if (IsServer)
        {
            var step = speed * Time.deltaTime;
           // transform.position = Vector3.MoveTowards(transform.position, destination.position, step);
        }
    }
}



