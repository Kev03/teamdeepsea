using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TeamDeepSeaSession newSession = new TeamDeepSeaSession();
        string newSessionJSON = JsonUtility.ToJson(newSession);
        PlayerPrefs.SetString("activeSession", newSessionJSON);
        PlayerPrefs.Save();
    }

}
