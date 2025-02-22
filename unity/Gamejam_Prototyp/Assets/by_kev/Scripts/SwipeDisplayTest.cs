using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwipeDisplayTest : MonoBehaviour
{

    public UnityEvent<SwipeInputDetect.SwipeDirection> OnSwipeTest;

    private int current = 0;

    public void SwipeTest()
    {
        SwipeInputDetect.SwipeDirection direction;

        switch (current)
        {
            case 0: { direction = SwipeInputDetect.SwipeDirection.Up; break; }
            case 1: { direction = SwipeInputDetect.SwipeDirection.Right; break; }
            case 2: { direction = SwipeInputDetect.SwipeDirection.Down; break; }
            case 3: { direction = SwipeInputDetect.SwipeDirection.Left; break; }
            default: { direction = SwipeInputDetect.SwipeDirection.Up; break; }
        }

        OnSwipeTest?.Invoke(direction);
        current = (current + 1) % 4;
    }



}
