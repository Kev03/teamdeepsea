using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioOutputTest : MonoBehaviour
{

    public UnityEvent<string> OnAudioTest;

    private int current = 0;

    public void AudioTest()
    {
        string sfx;

        switch (current)
        {
            case 0: { sfx = "up"; break; }
            case 1: { sfx = "right"; break; }
            case 2: { sfx = "down"; break; }
            case 3: { sfx = "left"; break; }
            case 4: { sfx = "collect"; break; }
            default: { sfx = "up"; break; }
        }

        OnAudioTest?.Invoke(sfx);
        current = (current + 1) % 5;
    }



}
