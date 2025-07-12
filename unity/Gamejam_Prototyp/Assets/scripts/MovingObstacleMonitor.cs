using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingObstacleMonitor : MonoBehaviour
{

    public UnityEvent<SerializableList<MovingSyncdObjectWrapper>> OnUpdateRequest;

    [SerializeField]
    private BackgroundObjectsMovement[] movingObjects;

    private long lastknownTimeStamp = -1;

    public void UpdateMovingObjects()
    {

        SerializableList<MovingSyncdObjectWrapper> currentObjectsData = new SerializableList<MovingSyncdObjectWrapper>();

        foreach(BackgroundObjectsMovement backgroundObjectsMovement in movingObjects)
        {
            currentObjectsData.list.Add(backgroundObjectsMovement.GetWrapper());
        }

        OnUpdateRequest?.Invoke(currentObjectsData);

    }

    public void ReceiveMovingObjectUpdate(SerializableList<MovingSyncdObjectWrapper> newObjectData)
    {
        if(newObjectData.timestamp <= lastknownTimeStamp) return;

        Debug.Log("Hey i received something: " + newObjectData.list.Count);
        lastknownTimeStamp = newObjectData.timestamp;

        foreach(MovingSyncdObjectWrapper wrapper in newObjectData.list)
        {
            Debug.Log("Looking at: " + movingObjects.Length);
            foreach(BackgroundObjectsMovement backgroundObjectsMovement in movingObjects)
            {
                Debug.Log("Checking if its the same as " + backgroundObjectsMovement.ID + " | " + (backgroundObjectsMovement.ID == wrapper.ID));
                if(backgroundObjectsMovement.ID == wrapper.ID)
                {
                    Debug.Log("Repositioned: " + backgroundObjectsMovement.ID + ": " + wrapper.Position);
                    backgroundObjectsMovement.Reposition(wrapper.Position);
                }
            }
        }
    }

    

}
