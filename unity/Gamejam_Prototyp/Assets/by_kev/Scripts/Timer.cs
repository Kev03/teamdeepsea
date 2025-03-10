using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{ 
    public UnityEvent OnTimeout; 

    [SerializeField]
    protected float waittime;
    public float Waittime
    {
        get { return waittime; }
        set { waittime = value; }
    }

    [SerializeField]
    protected bool startOnAwake = false;

    [SerializeField]
    protected bool oneShot = false;

    protected float timeout;

    private bool isActive = false;

    [SerializeField]
    private string timerName = "";
    // Start is called before the first frame update
    void Start()
    {
        if (startOnAwake)
        {
            SetTimeOut();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Timer is active: " + timerName);
        //Debug.Log(gameObject);
        if(isActive && (Time.time > timeout))
        {
            OnTimeOut();
          //  Debug.Log("Timer timeout: " + timerName);
        }
    }

    protected virtual void SetTimeOut()
    {
        timeout = Time.time + waittime;
        isActive = true;
    }

    private void OnTimeOut()
    {
        if (!oneShot) {
            SetTimeOut();
        }
        else
        {
            isActive = false;
        }

        OnTimeout?.Invoke();
    }

    public void Stop()
    {
        isActive =false;
    }

    public void Run()
    {
        SetTimeOut();
    }

}
