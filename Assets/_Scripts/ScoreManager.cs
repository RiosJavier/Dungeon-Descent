using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text highscoreText;

    private int score;
    private int highscore;
    private List<int> topScores = new List<int>();  // Define the topScores list

    void Start()
    {
        score = 0;
        highscore = 0;
        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
        // Load top scores here if needed
    }

    public void Addpoint()
    {
        score++;
        scoreText.text = score.ToString() + " POINTS";

         if (highscore < score)
         {
             highscore = score;
             PlayerPrefs.SetInt("Highscore", highscore);
            highscoreText.text = "HIGHSCORE: " + highscore.ToString();
         }

        // score--;
        // Update top scores list if needed here
    }

    public List<int> GetTopScores()
    {
        // Return a copy of the top scores list
        // You might want to sort or limit the list before returning
        return new List<int>(topScores);
    }

    void Awake()
{
    if (instance == null)
    {
        instance = this;
        // Optionally, to persist the ScoreManager across scenes, uncomment the following line:
        // DontDestroyOnLoad(gameObject);
    }
    else if (instance != this)
    {
        Destroy(gameObject); // Destroy any duplicate instances that may be created
    }
}

    // You might want to add methods to manage topScores, like adding new scores and sorting
}

