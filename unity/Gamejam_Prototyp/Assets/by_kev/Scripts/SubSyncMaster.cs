using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class SubSyncMaster : MonoBehaviour
{

    [SerializeField]
    private float offset = 10.0f;

    private Vector3 lastPos;
    
    public void CheckPosChange()
    {
        if(Vector3.Distance(transform.position, lastPos) > offset)
        {
            //Debug.Log("New Pos communicated");
            StartCoroutine(OnNewPosition("https://www.dh-profil.uni-tuebingen.de/gamejam/sub-pos-receiver.php?pos=" + transform.position.ToString()));
            lastPos = transform.position;
        }
    }


    IEnumerator OnNewPosition(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {

            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    //Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    //Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    //Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }





}
