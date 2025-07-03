using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PositionReset : MonoBehaviour
{
    public void ResetPosition()
    {
        Vector3 initialSubPosition = new Vector3(-50, 150, 0);
        StartCoroutine(OnNewPosition("https://www.dh-profil.uni-tuebingen.de/gamejam/sub-pos-receiver.php?pos=" + initialSubPosition.ToString()));
        Vector3 initialDiverPosition = new Vector3(-50, 100, 0);
        StartCoroutine(OnNewPosition("https://www.dh-profil.uni-tuebingen.de/gamejam/diver-pos-receiver.php?pos=" + initialDiverPosition.ToString()));
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
