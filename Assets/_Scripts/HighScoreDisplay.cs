using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighScoreDisplay : MonoBehaviour
{
    public ScoreManager scoreManager;
    public Text highScoresText;

    void Start()
    {
        DisplayHighScores();
    }

    private void DisplayHighScores()
    {
        List<int> topScores = scoreManager.GetTopScores();  // Updated method name

        if (topScores != null && topScores.Count > 0)
        {
            highScoresText.text = "High Scores:\n";
            foreach (int score in topScores)
            {
                highScoresText.text += $"{score}\n";
            }
        }
        else
        {
            highScoresText.text = "No high scores yet.";
        }
    }
}

