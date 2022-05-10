using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

// This script is for the main menu, handling button inputs

public class NavigationManager : MonoBehaviour
{
    public Text currentPlayer;
    public Text hiScoreText;
    public GameObject scoreManager;
    public string nameEntry;

    // Finds the singleton ScoreManager gameobject, runs scripts to load current player and high score on screen.
    public void Start()
    {
        scoreManager = GameObject.Find("ScoreManager");
        CurrentPlayer();
        HiScoreDisplay();
    }

    // Handles the text input for player name
    public void PlayerNameInput(string s)
    {
        nameEntry = (s);
        nameEntry = nameEntry.ToUpper();
        ScoreManager.currentName = nameEntry;
        CurrentPlayer();
    }

    // Sets the current player name at the bottom of the screen
    public void CurrentPlayer()
    {
        currentPlayer.text = "Current Player: " + ScoreManager.currentName;
    }

    // loads main scene
    public void StartGame()
    {
        // If no player name entered, set nameEntry to default "unknown"
        if (nameEntry == null)
        {
            nameEntry = "unknown";
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    // ends playtest if in Unity, closes application otherwise
    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    // Reset score button, for debugging/testing.
    public void ResetScore()
    {
        ScoreManager.SaveScore("unknown", 0);
        HiScoreDisplay();
    }

    // Loads current hi-score and displays it
    public void HiScoreDisplay()
    {
        ScoreManager.LoadScore();
        string hName = ScoreManager.hiScoreName;
        int hScore = ScoreManager.hiScore;
        hiScoreText.text = "High Score: " + hName + " - " + hScore;
    }
}
