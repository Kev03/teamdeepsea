using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SubmarineMessageInterpreter : MonoBehaviour
{


    public UnityEvent OnTimoutDetection;
    public UnityEvent<bool> OnLightSwitchChange;
    public UnityEvent<bool> OnAlignmentSwitch;

    public UnityEvent<Vector3> OnNewSubmarinePosition;
    public UnityEvent<SerializableList<SingleSubmarineMessage>> OnSubmarineMessagesReceived;

    private long lastKnownTimestamp = -1;

    public void OnFeedback(string feedback)
    {
        
        if (feedback == "{}")
        {
            Debug.Log("No Submarine Data avail yet");
            return;
        }

        SubmarineMessageWrapper submarineMessageWrapper = JsonUtility.FromJson<SubmarineMessageWrapper>(feedback);

        if (lastKnownTimestamp == submarineMessageWrapper.messagesToDiver.timestamp)
        {
            Debug.Log("No new divermessage");

            // Check for Timeout and 

        }
        else
        {
            lastKnownTimestamp = submarineMessageWrapper.messagesToDiver.timestamp;

            OnSubmarineMessagesReceived?.Invoke(submarineMessageWrapper.messagesToDiver);
        }

        OnNewSubmarinePosition?.Invoke(submarineMessageWrapper.submarinePosition);
        OnLightSwitchChange?.Invoke(submarineMessageWrapper.lightActive);
    }

    public void OnFeedback(SubmarineMessageWrapper submarineMessageWrapper)
    {

        if (lastKnownTimestamp == submarineMessageWrapper.messagesToDiver.timestamp)
        {
            Debug.Log("No new divermessage");

            // Check for Timeout and 

        }
        else
        {
            lastKnownTimestamp = submarineMessageWrapper.messagesToDiver.timestamp;

            OnSubmarineMessagesReceived?.Invoke(submarineMessageWrapper.messagesToDiver);
        }

        if(submarineMessageWrapper.submarinePosition != Vector3.zero)
        {
            OnNewSubmarinePosition?.Invoke(submarineMessageWrapper.submarinePosition);
        }
        
        OnLightSwitchChange?.Invoke(submarineMessageWrapper.lightActive);
        OnAlignmentSwitch?.Invoke(submarineMessageWrapper.alignment);
    }

}
