using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Came with project files, kept it on main scene and let it handle the gameplay only. Added score saving functionality.
// Hate the fact that the official unity exercise comes with capitalised variables.

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text hiScoreText;
    public GameObject GameOverText;
    public GameObject scoreManager;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    // Loads current hi-score
    private void Awake()
    {
        scoreManager = GetComponent<GameObject>();
        SetHiScore();
    }

    // Start is called before the first frame update
    void Start()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);

        // If the current score is higher than the saved hi-score, then set new hi-score
        if (m_Points > ScoreManager.hiScore)
        {
            ScoreManager.currentScore = m_Points;
            ScoreManager.SaveScore(ScoreManager.currentName, ScoreManager.currentScore);
            SetHiScore();
        }        
        // Creates new object from Scores class (to be used if high-score table is implemented)
       // ScoreManager.ScoreEntry();        
    }

    // Loads current Hi-score and sets the text at the top of the game.
    public void SetHiScore()
    {
        ScoreManager.LoadScore();
        hiScoreText.text = "Best Score: " + ScoreManager.hiScoreName + ": " + ScoreManager.hiScore;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
