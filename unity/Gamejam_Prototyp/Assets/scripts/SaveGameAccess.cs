using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveGameAccess : MonoBehaviour
{
    private SaveGame saveGame;
    private string saveGamePath;

    private void Awake()
    {
        saveGamePath = Application.persistentDataPath + Path.DirectorySeparatorChar + "savegame.json";
        if (!SaveGameExists())
        {
            InitSaveGame();
        }
        else
        {
            LoadSaveGame();
        }
    }

    private bool SaveGameExists()
    {
        return File.Exists(saveGamePath);
    }

    public void InitSaveGame()
    {
        SaveGame newSaveGame = new SaveGame();
        this.saveGame = newSaveGame;
        StoreSaveGame();
    }

    private void StoreSaveGame()
    {
        string saveGameString = JsonUtility.ToJson(saveGame);
        Debug.Log(saveGameString);
        File.WriteAllText(saveGamePath, saveGameString);
    }

    private void LoadSaveGame()
    {
        string saveGameString = File.ReadAllText(saveGamePath);
        saveGame = JsonUtility.FromJson<SaveGame>(saveGameString);
    }

    public bool IntroIsPlayed()
    {
        return saveGame.IntroPlayed;
    }

    public void OnIntroFinished()
    {
        saveGame.IntroPlayed = true;
        StoreSaveGame();
    }

}
