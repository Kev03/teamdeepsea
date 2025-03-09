using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntroCheck : MonoBehaviour
{
    public UnityEvent PlayIntro;

    [SerializeField]
    private SaveGameAccess saveGameAccess;

    private void Start()
    {
        if (!saveGameAccess.IntroIsPlayed())
        {
            PlayIntro?.Invoke();
        }
        else
        {
            Destroy(gameObject);
        }
    }



}
