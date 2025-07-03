using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class PlaystateFeedbackInterpretor : MonoBehaviour
{
    public UnityEvent<DiverMessageWrapper> OnDiverMessage;
    public UnityEvent<SubmarineMessageWrapper> OnSubmarineMessage;
    public UnityEvent<SerializableList<string>> OnClamData;


    private void Start()
    {/*
        string foo = "{\"diverMessageWrapper\": {\"diverPosition\":{\"x\":166.1687774658203,\"y\":106.28877258300781,\"z\":0.0},\"messagesToSubmarine\":{\"list\":[],\"timestamp\":133957025473610458}}, \"clamDataToUpdate\": {\"list\": [\"c1\",\"c4\",\"c3\"],\"timestamp\": -1}}";
        PlayState testState = JsonUtility.FromJson<PlayState>(foo);

        /*Debug.Log("-------------- Here to see ---------------");
        Debug.Log(testState.diverMessageWrapper.diverPosition);
        Debug.Log("-------------- Done ---------------");*/
    }

    public void OnFeedbackReceived(string feedback)
    {
        Debug.Log("Playstate Feedback: " + feedback);

        PlayState playstate = JsonUtility.FromJson<PlayState>(feedback);
        Debug.Log("DiverMessageWrapper: " + playstate.diverMessageWrapper.diverPosition);
        Debug.Log("SubmarineMessageWrapper: " + playstate.submarineMessageWrapper.submarinePosition);
        /*
        foreach (string collectableId in playstate.clamDataToUpdate.list)
        {
            Debug.Log("ID found: " + collectableId);
        }*/
        
        OnDiverMessage?.Invoke(playstate.diverMessageWrapper);
        OnSubmarineMessage?.Invoke(playstate.submarineMessageWrapper);
        OnClamData?.Invoke(playstate.clamDataToUpdate);

    }


}
