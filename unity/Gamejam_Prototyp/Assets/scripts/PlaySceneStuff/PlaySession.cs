using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlaySession : MonoBehaviour
{
    public UnityEvent<int> OnSessionDataLoaded;

    private TeamDeepSeaSession teamDeepSeaSession;
    public TeamDeepSeaSession TeamDeepSeaSession
    {
        get { return teamDeepSeaSession; }
    }

    public static PlaySession Instance
    {
        get; private set;
    }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        teamDeepSeaSession = JsonUtility.FromJson<TeamDeepSeaSession>(PlayerPrefs.GetString("activeSession"));
        OnSessionDataLoaded?.Invoke(TeamDeepSeaSession.selectedWorld);
    }

}
