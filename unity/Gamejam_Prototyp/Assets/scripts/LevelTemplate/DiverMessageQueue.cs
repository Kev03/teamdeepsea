using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DiverMessageQueue : MonoBehaviour
{

    public UnityEvent<string> ShowMessage;

    private Queue<SingleDiverMessage> queue = new Queue<SingleDiverMessage>();

    public void AddQueueElements(SerializableList<SingleDiverMessage> messages)
    {
        queue.Clear();

        foreach(SingleDiverMessage message in messages.list)
        {
            queue.Enqueue(message);
        }

    }

    public void RequestMessageShowing()
    {
        if (queue.Count == 0) return;

        SingleDiverMessage messageToShow = queue.Dequeue();

        string toShow = messageToShow.message.ToString();

        ShowMessage?.Invoke(toShow);

        Debug.Log(toShow);
    }

}
