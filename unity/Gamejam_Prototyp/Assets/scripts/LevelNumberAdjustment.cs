using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelNumberAdjustment : MonoBehaviour
{
    [SerializeField]
    private TMP_Text tMP_Text;

    public void OnChange(int levelNr)
    {
        tMP_Text.text = levelNr.ToString();
    }



}
