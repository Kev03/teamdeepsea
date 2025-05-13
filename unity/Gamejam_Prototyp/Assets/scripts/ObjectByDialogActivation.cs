using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectByDialogActivation : MonoBehaviour
{
    [SerializeField]
    private int[] positions;

    [SerializeField]
    private GameObject[] gameObjectsToActivate;

    public void ReceiveDialogMessage(DialogMessage dialogMessage)
    {
        
        for(int i = 0; i<positions.Length; i++)
        {
            if(dialogMessage.Position == positions[i])
            {
                gameObjectsToActivate[i].SetActive(true);
            }
        }

    }

}
