using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SubmarineMessageQueue : MonoBehaviour
{
    public UnityEvent<string> ShowMessage;

    private Queue<SingleSubmarineMessage> queue = new Queue<SingleSubmarineMessage>();

    public void AddQueueElements(SerializableList<SingleSubmarineMessage> messages)
    {
        queue.Clear();

        foreach (SingleSubmarineMessage message in messages.list)
        {
            queue.Enqueue(message);
        }

    }

    public void RequestMessageShowing()
    {
        if (queue.Count == 0) return;

        SingleSubmarineMessage messageToShow = queue.Dequeue();

        string toShow = messageToShow.message.ToString();

        ShowMessage?.Invoke(toShow);

        Debug.Log(toShow);
    }
}
