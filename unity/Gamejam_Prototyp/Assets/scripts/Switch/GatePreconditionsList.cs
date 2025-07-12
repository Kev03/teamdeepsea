using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GatePreconditionsList : MonoBehaviour
{
    public UnityEvent<string> PreconditionFullfilled;

    [SerializeField]
    private GatePrecondition[] preconditions;

    private Dictionary<GatePrecondition, bool> conditionsMet = new Dictionary<GatePrecondition, bool>();

    [SerializeField]
    private string id;

    public string ID
    {
        get { return id; }
    }

    private bool isMet = false;
    public bool IsMet
    {
        get { return isMet; }
    }

    private void Start()
    {
        foreach(GatePrecondition precondition in preconditions)
        {
            conditionsMet.Add(precondition, false);
            precondition.OnPreconditionMet.AddListener(PreconditionMet);
        }
    }

    public void PreconditionMet(GatePrecondition precondition)
    {
        conditionsMet[precondition] = true;
        if (CheckFullfillment())
        {
            MeetPrerequisites();
        }
    }

    private bool CheckFullfillment()
    {
        bool fullfilled = true;
        foreach(GatePrecondition precondition in conditionsMet.Keys)
        {
            fullfilled &= conditionsMet[precondition];
        }

        return fullfilled;

    }

    public void MeetPrerequisites()
    {
        PreconditionFullfilled?.Invoke(id);
        isMet = true;
    }



}
