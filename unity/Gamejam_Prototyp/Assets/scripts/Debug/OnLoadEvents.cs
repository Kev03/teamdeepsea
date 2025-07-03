using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnLoadEvents : MonoBehaviour
{

    public UnityEvent<ThikkGames.PlayerType, int> OnStart;

    public ThikkGames.PlayerType playerType;
    public int sessionID;


    // Start is called before the first frame update
    void Start()
    {
        OnStart?.Invoke(playerType, sessionID);
    }

}
