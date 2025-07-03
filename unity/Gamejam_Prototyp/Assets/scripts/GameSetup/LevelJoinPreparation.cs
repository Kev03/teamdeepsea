using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelJoinPreparation : MonoBehaviour
{

    public UnityEvent OnLevelPrepared;
    public UnityEvent<string> OnJoiningException;

    public void OnWebFeedback(string feedback)
    {
        SessionJoinFeedback sessionJoinFeedback = JsonUtility.FromJson<SessionJoinFeedback>(feedback);
        Debug.Log("SJF received: " + sessionJoinFeedback.ToString());

        if (SessionJoined(sessionJoinFeedback))
        {
            StartSessionOnClient(sessionJoinFeedback);
        }
        else
        {
            OnJoiningException?.Invoke(sessionJoinFeedback.feedback);
        }

    }

    private bool SessionJoined(SessionJoinFeedback sessionJoinFeedback)
    {
        return sessionJoinFeedback.feedback == "Joined Session";
    }

    private void StartSessionOnClient(SessionJoinFeedback sessionJoinFeedback)
    {
        TeamDeepSeaSession session = JsonUtility.FromJson<TeamDeepSeaSession>(PlayerPrefs.GetString("activeSession"));
        session.SelectedWorld = sessionJoinFeedback.LevelJoined;

        PlayerPrefs.SetString("activeSession", JsonUtility.ToJson(session));
        PlayerPrefs.Save();

        OnLevelPrepared?.Invoke();
    }

}
