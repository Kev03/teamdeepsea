using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelPreparation : MonoBehaviour
{

    public UnityEvent OnLevelPrepared;

    public void OnWebFeedback(string feedback)
    {
        Debug.Log("BAM");

        SessionCreationFeedback sessionCreationFeedback = JsonUtility.FromJson<SessionCreationFeedback>(feedback);

        TeamDeepSeaSession session = JsonUtility.FromJson<TeamDeepSeaSession>(PlayerPrefs.GetString("activeSession"));
        session.SessionID = sessionCreationFeedback.SessionID;
        PlayerPrefs.SetString("activeSession", JsonUtility.ToJson(session));
        PlayerPrefs.Save();
        OnLevelPrepared?.Invoke();
    }

}
