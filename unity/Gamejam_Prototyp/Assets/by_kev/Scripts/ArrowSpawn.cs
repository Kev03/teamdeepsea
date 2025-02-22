using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArrowSpawn : MonoBehaviour
{
    private UnityEvent<GameObject> onSpawn;

    [SerializeField] private GameObject arrowPrefab;

    [SerializeField, Tooltip("Positions of the arrow 0: Above, 1: Right, 2: Beneath, 3: Left")]
    private Transform[] positions;

    public void SpawnPrefab(SwipeInputDetect.SwipeDirection direction)
    {
        GameObject instance = Instantiate(arrowPrefab, this.transform.position, Quaternion.identity);
        Vector3 rotation = GetRotation(direction);
        Vector3 position = GetPosition(direction);
        instance.GetComponent<Arrow>().Init(rotation, position);
        onSpawn?.Invoke(instance);
        Debug.Log("Spawned!");
    }

    private Vector3 GetRotation(SwipeInputDetect.SwipeDirection direction)
    {
        Vector3 rotation = Vector3.zero;

        switch (direction)
        {
            case SwipeInputDetect.SwipeDirection.Right:
                {
                    rotation = new Vector3(0,0,270); //Vector3.back;
                    break;
                }
            case SwipeInputDetect.SwipeDirection.Down:
                {
                    rotation = new Vector3(0, 0, 180);  //2 * Vector3.back;
                    break;
                }
            case SwipeInputDetect.SwipeDirection.Left:
                {
                    rotation = new Vector3(0, 0, 90); //3 * Vector3.back;
                    break;
                }
            default:
                {
                    rotation = Vector3.zero;
                    break;
                }
        }

        return rotation;
    }

    private Vector3 GetPosition(SwipeInputDetect.SwipeDirection direction)
    {
        Vector3 position = positions[0].position;

        switch (direction)
        {
            case SwipeInputDetect.SwipeDirection.Right:
                {
                    position = positions[1].position;
                    break;
                }
            case SwipeInputDetect.SwipeDirection.Down:
                {
                    position = positions[2].position;
                    break;
                }
            case SwipeInputDetect.SwipeDirection.Left:
                {
                    position = positions[3].position;
                    break;
                }
            default:
                {
                    position = positions[0].position;
                    break;
                }
        }

        return position;
    }



}
