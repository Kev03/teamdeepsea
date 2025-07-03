using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlaystateCommunication : MonoBehaviour
{
    public UnityEvent<string> OnSendGameState;

    private GameObject activePlayer;

    public GameObject ActivePlayer
    {
        set { activePlayer = value; }
    }

    [SerializeField]
    private LevelSetup levelSetup;

    private PlayState currentPlaystate;

    private void Start()
    {
        currentPlaystate = new PlayState();
    }

    public void ChangeSubmarineMessage(SubmarineMessageWrapper submarineMessageWrapper)
    {
        currentPlaystate.submarineMessageWrapper = submarineMessageWrapper;
        SendGameState();
    }

    public void ChangeDiverMessage(DiverMessageWrapper diverMessageWrapper)
    {
        currentPlaystate.diverMessageWrapper = diverMessageWrapper;
        SendGameState();
    }

    public void SendGameState()
    {
        Debug.Log("SENDING STUFF!");
        string playstateJSON = JsonUtility.ToJson(currentPlaystate);

        string urlAppendix = $"?player_type={levelSetup.PlayerType}&session_id={levelSetup.SessionID}&message={playstateJSON}";

        OnSendGameState?.Invoke(urlAppendix);

        currentPlaystate.clamDataToUpdate.ResetList();
    }

    public void AddClamCollection(SerializableClamData serializableClamData)
    {
        Debug.Log("Added to clamlist: " + serializableClamData);
        currentPlaystate.clamDataToUpdate.list.Add(serializableClamData.ID);
    }

}
