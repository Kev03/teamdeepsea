using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Swipe detection based on this youtube tutorial: https://www.youtube.com/watch?v=Pca9LMd8WsM
/// </summary>

public class SwipeInputDetect : MonoBehaviour
{

    public enum SwipeDirection
    {
        Left,
        Right,
        Up,
        Down
    }

    public UnityEvent<SwipeDirection> SwipeDetected = new UnityEvent<SwipeDirection>();

    [SerializeField]
    private float offset = 1.0f;

    private Vector2 touchStart;
    private Vector2 touchEnd;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchStart = Input.GetTouch(0).position;
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            touchEnd = Input.GetTouch(0).position;
            DetectSwipe();
        }
    }

    private void DetectSwipe()
    {
        if (touchEnd.x < touchStart.x - offset)
        {
            SwipeDetected?.Invoke(SwipeDirection.Left);
        }
        else if (touchEnd.x > touchStart.x + offset)
        {
            SwipeDetected?.Invoke(SwipeDirection.Right);
        }
        else if (touchEnd.y < touchStart.y - offset)
        {
            SwipeDetected?.Invoke(SwipeDirection.Down);
        }else if(touchEnd.y > touchStart.y + offset)
        {
            SwipeDetected?.Invoke(SwipeDirection.Up);
        }
        else
        {
            Debug.Log("Nothing");
        }

    }

}
