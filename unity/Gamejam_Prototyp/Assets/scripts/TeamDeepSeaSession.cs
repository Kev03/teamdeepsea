using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TeamDeepSeaSession
{
    public int sessionID = 0;
    public int SessionID
    {
        get { return sessionID; }
        set { sessionID = value; }
    }

    public ThikkGames.PlayerType playerType = ThikkGames.PlayerType.Submarine;
    public ThikkGames.PlayerType PlayerType{
        get { return playerType; }
        set { playerType = value; }
    }
    
    public int selectedWorld = 0;

    public int SelectedWorld
    {
        get { return selectedWorld; }
        set { selectedWorld = value; }
    }

    public override string ToString()
    {
        return $"Session ID: {sessionID}, PlayerType: {playerType}, Selected World: {selectedWorld}";
    }

}
