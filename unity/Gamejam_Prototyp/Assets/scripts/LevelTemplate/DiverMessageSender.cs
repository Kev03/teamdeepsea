using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DiverMessageSender : MonoBehaviour
{
    public UnityEvent<string> OnSendMessage;
    public UnityEvent<DiverMessageWrapper> OnSendMessageNew;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private LevelSetup levelSetup;

    [SerializeField]
    private GameObject visibleDiver;

    private DiverMessageWrapper currentWrapper;

    private void Start()
    {
        currentWrapper = new DiverMessageWrapper();
    }

    public void SendRequest()
    {
        currentWrapper.diverPosition = player.transform.position;
        currentWrapper.alignment = (visibleDiver.transform.eulerAngles.y == 180);

        string messageAsJSON = JsonUtility.ToJson(currentWrapper);

        string urlAppendix = $"?player_type={levelSetup.PlayerType}&session_id={levelSetup.SessionID}&message={messageAsJSON}";

        OnSendMessage?.Invoke(urlAppendix);
        OnSendMessageNew?.Invoke(currentWrapper);

        Debug.Log("WRAPPER: " + messageAsJSON);
    }

    public void AddMessageForSubmarine(string type)
    {
        currentWrapper = new DiverMessageWrapper();

        SingleDiverMessage.DiverMessageTypes message = (SingleDiverMessage.DiverMessageTypes)System.Enum.Parse(typeof(SingleDiverMessage.DiverMessageTypes), type);
        currentWrapper.messagesToSubmarine.list.Add(new SingleDiverMessage(message));
    }

}
