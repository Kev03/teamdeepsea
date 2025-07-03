using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncSceneLoader : MonoBehaviour
{

    private AsyncOperation asyncLoad;

    [SerializeField]
    private int sceneBuildIndex;

    [SerializeField]
    private bool sceneSwitchPermit = false;

    [SerializeField]
    private bool debugLog = false;

    [SerializeField]
    private bool startAsyncLoading = false;

    public bool SceneSwitchPermit
    {
        set { sceneSwitchPermit = value; }
    }

    IEnumerator LoadAsyncScene()
    {
        asyncLoad = SceneManager.LoadSceneAsync(sceneBuildIndex, LoadSceneMode.Single);
        asyncLoad.allowSceneActivation = false;
        //wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            if (debugLog) Debug.Log(asyncLoad.progress);
            //scene has loaded as much as possible,
            // the last 10% can't be multi-threaded
            if (asyncLoad.progress >= 0.9f && sceneSwitchPermit)
            {
                asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }
        
    }

    private void Start()
    {
        if(debugLog) Debug.Log("Hi there");
        if(startAsyncLoading) StartCoroutine(LoadAsyncScene()); 
    }

    public void ChangeScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex, LoadSceneMode.Single);
    }


}
