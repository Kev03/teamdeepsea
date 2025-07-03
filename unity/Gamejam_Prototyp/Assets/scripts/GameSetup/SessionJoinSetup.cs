using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SessionJoinSetup : MonoBehaviour
{

    public UnityEvent<string> OnSessionJoin;
    public UnityEvent<string> OnMissingSessionID;

    private int sessionID = -1;

    public int SessionID
    {
        get { return sessionID; }
        set { sessionID = value; }
    }

    [SerializeField]
    private ThikkGames.PlayerType chosenPlayerType;

    public ThikkGames.PlayerType ChosenPlayerType
    {
        get { return chosenPlayerType; }
        set { chosenPlayerType = value; }
    }

    public void ChosePlayerType(int type)
    {
        if (type == 0) { ChosenPlayerType = ThikkGames.PlayerType.Diver; }
        else { ChosenPlayerType = ThikkGames.PlayerType.Submarine; }
    }

    public void StartSession()
    {
        if(SessionID == -1)
        {
            OnMissingSessionID?.Invoke("Please enter SessionID");
            return;
        }

        string deviceUniqueIdentifier = SystemInfo.deviceUniqueIdentifier;
        string playerType = chosenPlayerType.ToString();
        string appendix = $"?session_id={sessionID}&player_type={playerType}&player_uid={deviceUniqueIdentifier}";

        StoreSessionToPrefs();

        OnSessionJoin?.Invoke(appendix);
        

    }

    public void SetSessionID(string sessionID)
    {
        if (Int32.TryParse(sessionID, out _))
        {
            SessionID = Int32.Parse(sessionID);
        }
        else
        {
            SessionID = -1;
        }
        
    }

    private void StoreSessionToPrefs()
    {
        TeamDeepSeaSession session = JsonUtility.FromJson<TeamDeepSeaSession>(PlayerPrefs.GetString("activeSession"));
        session.PlayerType = chosenPlayerType;
        session.sessionID = SessionID;
        string sessionJSON = JsonUtility.ToJson(session);
        PlayerPrefs.SetString("activeSession", sessionJSON);
        PlayerPrefs.Save();
    }

}
