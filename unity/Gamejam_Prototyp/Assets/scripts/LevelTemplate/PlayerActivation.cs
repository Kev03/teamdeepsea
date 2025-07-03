using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerActivation : MonoBehaviour
{
    public UnityEvent OnSessionActive;

    public void OnSessionActivated()
    {
        OnSessionActive?.Invoke();
    }

}
