using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class DiverSyncSlave : MonoBehaviour
{
    public UnityEvent<Vector3> TargetPos;

    public void CheckPosChange()
    {
        StartCoroutine(GetPosition("https://www.dh-profil.uni-tuebingen.de/gamejam/diver-pos-access.php"));    
    }


    IEnumerator GetPosition(string uri)
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
                    OnDataReceived(webRequest.downloadHandler.text);
                    break;
            }
        }
    }

    private void OnDataReceived(string data)
    {
        
        float x = float.Parse(data.Split(",")[1].Trim(new char[] { '(' , ')' }).Replace(".", ","));
        float y = float.Parse(data.Split(",")[2].Trim(new char[] { '(' , ')' }).Replace(".", ","));
        float z = float.Parse(data.Split(",")[3].Trim(new char[] { '(' , ')' }).Replace(".", ","));

        Vector3 newpos = new Vector3(x,y,z);

        TargetPos?.Invoke(newpos);
    }





}
