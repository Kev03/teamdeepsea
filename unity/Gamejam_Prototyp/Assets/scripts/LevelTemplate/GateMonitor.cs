using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GateMonitor : MonoBehaviour
{
    public UnityEvent<string> OnGateOpened;

    private GatePreconditionsList[] gatePreconditions;

    // Start is called before the first frame update
    void Start()
    {
        gatePreconditions = Object.FindObjectsOfType<GatePreconditionsList>();

        foreach(GatePreconditionsList preconditionsList in gatePreconditions)
        {
            preconditionsList.PreconditionFullfilled.AddListener(CommunicateGateOpened);
        }

    }

    private void CommunicateGateOpened(string id)
    {
        OnGateOpened?.Invoke(id);
    }

    public void OnGateMessageReceived(SerializableList<string> openedGates) 
    {
        foreach(string gateID in openedGates.list)
        {
            OpenGate(gateID);
        }
    
    }

    private void OpenGate(string id)
    {
        foreach(GatePreconditionsList list in gatePreconditions)
        {
            if(!list.IsMet && list.ID == id)
            {
                list.MeetPrerequisites();
            }
        }
    }

}
