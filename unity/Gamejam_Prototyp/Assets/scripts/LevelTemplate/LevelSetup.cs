using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelSetup : MonoBehaviour
{
    public UnityEvent<string> CheckSessionReady;

    public UnityEvent<Vector3, Vector3> OnSubmarineJoined;
    public UnityEvent<Vector3, Vector3> OnDiverJoinded;

    public UnityEvent StartSubmarinePlayer;
    public UnityEvent StartDiverPlayer;
    
    [SerializeField]
    private Transform initialSubmarinePosition;

    [SerializeField]
    private Transform initialDiverPosition;

    private ThikkGames.PlayerType playerType;
    public ThikkGames.PlayerType PlayerType
    {
        get { return playerType; }
    }

    private int sessionID;
    public int SessionID
    {
        get { return sessionID; }
    }

    public void Start()
    {

        string activeSession = PlayerPrefs.GetString("activeSession");
        TeamDeepSeaSession session = JsonUtility.FromJson<TeamDeepSeaSession>(activeSession);

        PrepareLevel(session.playerType, session.sessionID);
            
    }

    public void SetPlayerType(ThikkGames.PlayerType playerType)
    {
        this.playerType = playerType;
        
        if (playerType == ThikkGames.PlayerType.Submarine)
        {
            OnSubmarineJoined?.Invoke(initialSubmarinePosition.position, initialDiverPosition.position);
        }
        else
        {
            OnDiverJoinded?.Invoke(initialSubmarinePosition.position, initialDiverPosition.position);
        }

    }

    public void PrepareLevel(ThikkGames.PlayerType playerType, int sessionID)
    {
        SetPlayerType(playerType);
        this.sessionID = sessionID;
        CheckSessionReady?.Invoke(sessionID.ToString());
    }

    public void StartLevel()
    {
        if (playerType == ThikkGames.PlayerType.Submarine)
        {
            StartSubmarinePlayer?.Invoke();
        }
        else
        {
            StartDiverPlayer?.Invoke();
        }
    }

}
