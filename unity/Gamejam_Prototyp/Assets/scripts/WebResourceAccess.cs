using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class WebResourceAccess : MonoBehaviour
{
    public UnityEvent<string> OnFeedback;

    [SerializeField]
    private string url = "https://www.dh-profil.uni-tuebingen.de/gamejam/";

    [SerializeField]
    private string[] fieldnames;

    [SerializeField]
    private string[] fieldvalues;

    public void AccessWebResource()
    {
        string accessURL = url;
        if(fieldnames.Length > 0)
        {
            accessURL += "?";
            for(int i=0; i<fieldnames.Length; i++)
            {
                accessURL += (fieldnames[i] + "=" + fieldvalues[i]);
            }
        }

        StartCoroutine(GetRequest(accessURL));
    }

    public void AccessWebResource(string appendix)
    {

        string accessURL = url + appendix;

        Debug.Log("Accessing: " + accessURL);

        StartCoroutine(GetRequest(accessURL));
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
                    Debug.LogError(pages[page] + ": Connection Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("Feedback received");
                    Debug.Log(webRequest.downloadHandler.text);
                    OnFeedback?.Invoke(webRequest.downloadHandler.text);
                    break;
            }
        }
    }

}
