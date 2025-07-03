using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class DiverMessageInterpreter : MonoBehaviour
{
    public UnityEvent OnTimoutDetection;

    public UnityEvent<Vector3> OnNewDiverPosition;
    public UnityEvent<SerializableList<SingleDiverMessage>> OnDiverMessagesReceived;
    public UnityEvent<bool> OnAlignmentUpdate;

    private long lastKnownTimestamp = -1;

    public void OnFeedback(string feedback)
    {

        Debug.Log("Received Feedback: " + feedback);
        
        if (feedback == "{}")
        {
            Debug.Log("No Diver Data avail yet");
            return;
        }

        DiverMessageWrapper diverMessageWrapper = JsonUtility.FromJson<DiverMessageWrapper>(feedback);
        
        if(lastKnownTimestamp == diverMessageWrapper.messagesToSubmarine.timestamp)
        {
            Debug.Log("No new divermessage");
            
            // Check for Timeout and 
            
        }else{
            lastKnownTimestamp = diverMessageWrapper.messagesToSubmarine.timestamp;

            OnDiverMessagesReceived?.Invoke(diverMessageWrapper.messagesToSubmarine);
        }

        OnNewDiverPosition?.Invoke(diverMessageWrapper.diverPosition);

    }

    public void OnFeedback(DiverMessageWrapper diverMessageWrapper)
    {

        if (lastKnownTimestamp == diverMessageWrapper.messagesToSubmarine.timestamp)
        {
            Debug.Log("No new divermessage");

            // Check for Timeout and 

        }
        else
        {
            lastKnownTimestamp = diverMessageWrapper.messagesToSubmarine.timestamp;

            OnDiverMessagesReceived?.Invoke(diverMessageWrapper.messagesToSubmarine);
        }

        Debug.Log("New Diver Pos received: " + diverMessageWrapper.diverPosition);

        OnNewDiverPosition?.Invoke(diverMessageWrapper.diverPosition);
        OnAlignmentUpdate?.Invoke(diverMessageWrapper.alignment);
    }


}
