using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SessionSetup : MonoBehaviour
{
    public UnityEvent<string> OnSessionStart;

    [SerializeField]
    private int levelNr = 1;

    public int LevelNr
    {
        get { return levelNr; }
        set { levelNr = value; }
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
        if(type == 0) { ChosenPlayerType = ThikkGames.PlayerType.Diver; }
        else { ChosenPlayerType = ThikkGames.PlayerType.Submarine; }
    }

    public void StartSession()
    {
        string deviceUniqueIdentifier = SystemInfo.deviceUniqueIdentifier;
        string playerType = chosenPlayerType.ToString();
        Debug.Log(playerType);
        string getParameter = $"create_game.php?selected_world={levelNr}&player_type={playerType}&player_uid={deviceUniqueIdentifier}";

        StoreSessionToPrefs();

        OnSessionStart?.Invoke(getParameter);
    }

    private void StoreSessionToPrefs()
    {
        TeamDeepSeaSession session = JsonUtility.FromJson<TeamDeepSeaSession>(PlayerPrefs.GetString("activeSession"));
        session.PlayerType = chosenPlayerType;
        session.SelectedWorld = levelNr;
        string sessionJSON = JsonUtility.ToJson(session);
        PlayerPrefs.SetString("activeSession", sessionJSON);
        PlayerPrefs.Save();
    }
    

    

}
