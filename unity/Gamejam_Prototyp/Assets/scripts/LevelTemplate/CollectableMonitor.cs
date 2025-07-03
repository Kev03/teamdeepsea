using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectableMonitor : MonoBehaviour
{
    public UnityEvent OnAllCollectiblesCollected;
    public UnityEvent<SerializableClamData> OnClamCollected;

    private Collectable[] collectabes;

    // Start is called before the first frame update
    void Start()
    {
        collectabes = Object.FindObjectsOfType<Collectable>();
        
        foreach(Collectable collectable in collectabes)
        {
            collectable.OnCollected.AddListener(OnCollectableCollected);
        }
       
    }

    private void OnCollectableCollected(Collectable collectable)
    {
        SerializableClamData collectedClamData = new SerializableClamData(collectable);
        OnClamCollected?.Invoke(collectedClamData);

        CheckGameOver();
    }    

    private void CheckGameOver()
    {
        bool gameOver = true;
        
        foreach(Collectable collectable in collectabes)
        {
            gameOver &= !collectable.gameObject.activeInHierarchy;
        }
        
        if(gameOver) OnAllCollectiblesCollected?.Invoke();
                
    }

    public void OnCollectableMessageReceived(SerializableList<string> clamData)
    {
        foreach(string cd in clamData.list)
        {
            DeactivateClam(cd);
        }
        CheckGameOver();
    }

    private void DeactivateClam(string id)
    {
        foreach(Collectable cd in collectabes)
        {
            if(cd.gameObject.activeInHierarchy && cd.ID == id)
            {
                cd.gameObject.SetActive(false);
            }
        }
    }

}
