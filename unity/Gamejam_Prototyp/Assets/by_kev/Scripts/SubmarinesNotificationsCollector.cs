using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class SubmarinesNotificationsCollector : MonoBehaviour
{
    public UnityEvent<SwipeInputDetect.SwipeDirection> OnNewInput;

    private string lastTimeStamp = "";

    public void CheckForUpdates()
    {
        StartCoroutine(GetRequest("https://www.dh-profil.uni-tuebingen.de/gamejam/atv-access.php"));
    }

    IEnumerator GetRequest(string uri)
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
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    //Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    OnDataCollected(webRequest.downloadHandler.text);
                    break;
            }
        }
    }

    private void OnDataCollected(string content)
    {
        string timestamp = content.Split(",")[0];
        string arrow = content.Split(",")[1];

        if(lastTimeStamp != timestamp)
        {
            System.Enum.TryParse(arrow, out SwipeInputDetect.SwipeDirection direction);

            OnNewInput?.Invoke(direction);
            lastTimeStamp = timestamp;
        }

    }
}
