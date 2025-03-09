using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PortbackArea : MonoBehaviour
{

    [SerializeField]
    private Transform submarineRespawn;
    public Transform SubmarineRespawn
    {
        get { return submarineRespawn; }
        set { }
    }

    [SerializeField]
    private Transform diverRespawn;
    public Transform DiverRespawn
    {
        get { return diverRespawn; }
        set { }
    }

    [SerializeField]
    private string[] allowedColliders;
    public string[] AllowedColliders
    {
        get { return allowedColliders; }
        set { }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LastPortback.Instance.LastPortbackArea = this;   
    }

}
