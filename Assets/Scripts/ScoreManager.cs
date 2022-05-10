using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    // This script will handle holding/saving/loading the names and scores.

    public static int currentScore;
    public static string currentName;

    public static string hiScoreName;
    public static int hiScore;

    public static ScoreManager Instance;

    private void Awake()
    {
        Singleton();
    }

    // Singleton script, ensures exactly one instance of this script/gameObject is running at any time.
    private void Singleton()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Class for saving json data
    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int playerScore;
    }

    // Saves the current score
    public static void SaveScore(string n, int s)
    {
        SaveData data = new SaveData();
        data.playerName = n;
        data.playerScore = s;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    // Loads the current hi-score
    public static void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            hiScoreName = data.playerName;
            hiScore = data.playerScore;
        }
    }

    // - For future Hi-score table implementation - 
    // public static void ScoreEntry()
    // {
    //        List<Scores> scores = new List<Scores>();
    //        scores.Add(new Scores(nameEntry, score));
    //        Debug.Log(scores);
    // }
}
