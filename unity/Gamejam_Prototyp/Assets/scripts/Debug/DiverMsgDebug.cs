using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiverMsgDebug : MonoBehaviour
{

    public bool changeJSON = false;

    private int lastKnown = 0;

    private void Debug1()
    {
        
        DiverMessageWrapper diverMessageWrapper = new DiverMessageWrapper();

        diverMessageWrapper.diverPosition = new Vector3(-400, -144, 0);

        diverMessageWrapper.messagesToSubmarine.list.Add(new SingleDiverMessage(SingleDiverMessage.DiverMessageTypes.up));

        string json = JsonUtility.ToJson(diverMessageWrapper);
        Debug.Log("Diver says: " + json);

    }

    private void Debug2()
    {

        DiverMessageWrapper diverMessageWrapper = new DiverMessageWrapper();

        diverMessageWrapper.diverPosition = new Vector3(-370, -140, 0);

        diverMessageWrapper.messagesToSubmarine.list.Add(new SingleDiverMessage(SingleDiverMessage.DiverMessageTypes.wait));

        string json = JsonUtility.ToJson(diverMessageWrapper);
        Debug.Log("Diver says: " + json);

    }

    private void Update()
    {
        if (changeJSON)
        {
            if(lastKnown == 0)
            {
                Debug1();
            }
            else
            {
                Debug2();
            }
            lastKnown = (lastKnown + 1) % 2;
            changeJSON = false;
        }
    }



}
