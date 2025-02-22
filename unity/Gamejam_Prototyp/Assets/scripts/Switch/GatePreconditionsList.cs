using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GatePreconditionsList : MonoBehaviour
{
    public UnityEvent PreconditionFullfilled;

    [SerializeField]
    private GatePrecondition[] preconditions;

    private Dictionary<GatePrecondition, bool> conditionsMet = new Dictionary<GatePrecondition, bool>();

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
            PreconditionFullfilled?.Invoke();
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





}
