using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelInstantiation : MonoBehaviour
{
    public UnityEvent<string> OnException;
    public UnityEvent OnLevelPlaced;


    [SerializeField]
    private GameObject[] levels;

    [SerializeField]
    private GameObject levelPlacement;

    public void StartLevel(int levelNr)
    {
        if(levelNr > levels.Length)
        {
            OnException?.Invoke("Something went wrong. Please reload and restart again!");
            Debug.Log("Failure: Loaded wrong level!");
            return;
        }

        GameObject levelInstance = Instantiate(levels[levelNr - 1]);
        levelInstance.transform.SetParent(levelPlacement.transform);
        OnLevelPlaced?.Invoke();
    }




}
