using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SessionReadyCheck : MonoBehaviour
{
    public UnityEvent<string> checkSessionState;
    public UnityEvent OnSessionReady;
    public UnityEvent OnSessionPending;
    public UnityEvent<Vector3,Vector3> OnRejoin;
    public UnityEvent<SerializableList<string>> OnRejoinClamUpdate;
    
    private string sessionID;
    public string SessionID
    {
        get { return sessionID; }
        set { sessionID = value; }
    }

    [SerializeField]
    private GameObject initialDiverPos;

    [SerializeField]
    private GameObject initialSubmarinePos;

    public void CheckSession()
    {
        
        string urlAppendix = "?session_id=" + sessionID.ToString();

        checkSessionState?.Invoke(urlAppendix);
    }

    public void OnWebFeedback(string feedback)
    {
        SessionCheckFeedback sessionCheckFeedback = JsonUtility.FromJson<SessionCheckFeedback>(feedback);

        if(sessionCheckFeedback.Feedback == "Session Ready")
        {
            OnSessionJoined(sessionCheckFeedback);
        }
        else
        {
            OnSessionPending?.Invoke();
        }
    }

    private void OnSessionJoined(SessionCheckFeedback sessionCheckFeedback)
    {
        Vector3 diverPosition = initialDiverPos.transform.position;
        Vector3 submarinePosition = initialSubmarinePos.transform.position;

        if (sessionCheckFeedback.DiverMsg != "{}")
        {
            diverPosition = sessionCheckFeedback.GetDiverMessage().diverPosition;
            Debug.Log("Placed Diver: " + diverPosition);
        }

        if(sessionCheckFeedback.submarineMsg != "{}")
        {
            submarinePosition = sessionCheckFeedback.GetSubmarineMessage().submarinePosition;
            Debug.Log("Placed Sub: " + submarinePosition);
        }

        OnRejoin?.Invoke(submarinePosition, diverPosition);
        OnRejoinClamUpdate?.Invoke(sessionCheckFeedback.clamDataToUpdate);

        OnSessionReady?.Invoke();
    }

}
