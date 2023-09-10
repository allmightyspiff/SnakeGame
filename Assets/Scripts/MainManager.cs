using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    private SaveData userSaveData;

    private void Awake()
    {
        // If there is already an instance, we just kill this new instance in favor of the old one.
        if (Instance != null) {
            
            Destroy(gameObject);
            return;
        }
        Instance = this;
        Instance.userSaveData = Load();
        DontDestroyOnLoad(gameObject);
        Load();
    }

    [System.Serializable]
    private class SaveData
    {
        public string username = "Player1";
        public int highscore = 0;
        public int gamesPlayed = 0;
        public int lastScore = 0;
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(userSaveData);
        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);
    }

    private SaveData Load()
    {
        SaveData data = new();
        string path = Application.persistentDataPath + "/saveFile.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<SaveData>(json);
        }
        return data;
    }

    public void UpdateHighscore(int newScore)
    {
        userSaveData.lastScore = newScore;
        if (userSaveData.highscore < newScore) {
            userSaveData.highscore = newScore;
            Save();
        }

    }

    public int GetHighscore()
    {
        return userSaveData.highscore;
    }

    public int GetLastScore()
    {
        return userSaveData.lastScore;
    }

    public void UpdateUsername(string newName)
    {
        userSaveData.username = newName;
        Save();
    }

    public string GetUsername()
    {
        return userSaveData.username;
    }

    public void UpdateGamesPlayed()
    {
        userSaveData.gamesPlayed++;
    }

    public int GetGamesPlayed()
    {
        return userSaveData.gamesPlayed;
    }

}

