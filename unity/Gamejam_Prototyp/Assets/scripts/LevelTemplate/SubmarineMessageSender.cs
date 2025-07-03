using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SubmarineMessageSender : MonoBehaviour
{
    public UnityEvent<string> OnSendMessage;
    public UnityEvent<SubmarineMessageWrapper> OnSendMessageNew;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject visibleSub;
    
    [SerializeField]
    private LevelSetup levelSetup;

    private SubmarineMessageWrapper currentWrapper;

    private void Start()
    {
        currentWrapper = new SubmarineMessageWrapper();
    }

    public void SendRequest()
    {
        currentWrapper.submarinePosition = player.transform.position;
        
        Debug.Log("EA: " + visibleSub.transform.eulerAngles.y);
        currentWrapper.alignment = (visibleSub.transform.eulerAngles.y == 180.0);

        Debug.Log("AL: " + currentWrapper.alignment);

        string messageAsJSON = JsonUtility.ToJson(currentWrapper);
        
        string urlAppendix = $"?player_type={levelSetup.PlayerType}&session_id={levelSetup.SessionID}&message={messageAsJSON}";

        OnSendMessage?.Invoke(urlAppendix);
        OnSendMessageNew?.Invoke(currentWrapper);

        //Debug.Log("WRAPPER: " + messageAsJSON);
    }

    public void AddMessageForDiver(string type)
    {
        currentWrapper.messagesToDiver.ResetList();

        SingleSubmarineMessage.SubmarineMessageTypes message = (SingleSubmarineMessage.SubmarineMessageTypes)System.Enum.Parse(typeof(SingleSubmarineMessage.SubmarineMessageTypes), type);
        currentWrapper.messagesToDiver.list.Add(new SingleSubmarineMessage(message));
    }

    public void ToggleLight(bool currentLight)
    {
        currentWrapper.lightActive = currentLight;
    }

}
