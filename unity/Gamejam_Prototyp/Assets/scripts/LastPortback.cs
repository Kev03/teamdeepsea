using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPortback : MonoBehaviour
{

    public static LastPortback Instance
    {
        get; private set;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    private PortbackArea lastPortbackArea;
    public PortbackArea LastPortbackArea
    {
        set { lastPortbackArea = value; }
    }

    public void PortBack()
    {
        Submarine.Instance.transform.position = lastPortbackArea.SubmarineRespawn.position;
        Diver.Instance.transform.position = lastPortbackArea.DiverRespawn.position;
    }

}
