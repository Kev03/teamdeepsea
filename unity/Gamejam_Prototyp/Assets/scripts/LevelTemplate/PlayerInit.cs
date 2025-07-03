using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInit : MonoBehaviour
{
    public UnityEvent<GameObject> OnPlayerInitialized;

    [SerializeField]
    private GameObject submarine;

    [SerializeField]
    private GameObject diver;
    
    [SerializeField]
    private ThikkGames.PlayerType activePlayer;

    public void OnInit(Vector3 initialSubmarinePosition, Vector3 initialDiverPosition)
    {
        submarine.transform.position = initialSubmarinePosition;
        diver.transform.position = initialDiverPosition;

        GameObject activePlayerObject = activePlayer == ThikkGames.PlayerType.Submarine ? submarine : diver;
        OnPlayerInitialized?.Invoke(activePlayerObject);

    }

}
