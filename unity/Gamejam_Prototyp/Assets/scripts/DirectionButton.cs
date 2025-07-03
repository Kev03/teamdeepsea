using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DirectionButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
 
    public bool buttonPressed;
    public Direction direction;
    public UnityEvent<Direction> directionEvent;
    public UnityEvent releaseEvent;
 
    public void OnPointerDown(PointerEventData eventData){
        buttonPressed = true;
        Debug.Log("Pointer Down");
    }
 
    public void OnPointerUp(PointerEventData eventData){
        buttonPressed = false;
        releaseEvent?.Invoke();
        Debug.Log("Pointer Up");
    }

    private void Update()
    {
        if (buttonPressed)
        {
            directionEvent?.Invoke(direction);
        }
    }
}