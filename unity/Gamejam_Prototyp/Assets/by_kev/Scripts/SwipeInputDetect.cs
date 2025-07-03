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
    public UnityEvent<string> OnSwipeDetected;



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
            OnSwipeDetected?.Invoke(SingleDiverMessage.DiverMessageTypes.left.ToString());
            Debug.Log("Left swiped");
        }
        else if (touchEnd.x > touchStart.x + offset)
        {
            SwipeDetected?.Invoke(SwipeDirection.Right);
            OnSwipeDetected?.Invoke(SingleDiverMessage.DiverMessageTypes.right.ToString());
            Debug.Log("Right swiped");
        }
        else if (touchEnd.y < touchStart.y - offset)
        {
            SwipeDetected?.Invoke(SwipeDirection.Down);
            OnSwipeDetected?.Invoke(SingleDiverMessage.DiverMessageTypes.down.ToString());
            Debug.Log("Down swiped");
        }
        else if(touchEnd.y > touchStart.y + offset)
        {
            SwipeDetected?.Invoke(SwipeDirection.Up);
            OnSwipeDetected?.Invoke(SingleDiverMessage.DiverMessageTypes.up.ToString());
            Debug.Log("Up swiped");
        }
        else
        {
            Debug.Log("Nothing");
        }

    }

}
