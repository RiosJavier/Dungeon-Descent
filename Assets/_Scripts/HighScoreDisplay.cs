using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class HighScoreDisplay : MonoBehaviour
{
    public class HighScore : IComparer{
        public string date;
        public int score;
        public HighScore(string date, int score){
            this.date = date;
            this.score = score;
        }
        public int Compare(object x, object y){
            HighScore hs1 = (HighScore)x;
            HighScore hs2 = (HighScore)y;
            return hs1.score.CompareTo(hs2.score);
        }
    }
    // public ScoreManager scoreManager;
    public Text highScoresText;
    public ArrayList highScores;

    public TextAsset TA;

    void Start()
    {
        // populateHighScores();
        DisplayHighScores();
    }
    // private void populateHighScores()
    // {
    //     using (StreamReader sr = File.OpenText(Application.persistentDataPath + "/Assets/Fonts/HighscoreText.txt")){
    //         string line;
    //         while ((line = sr.ReadLine()) != null)
    //         {
    //             string[] data = line.Split(' ');
    //             highScores.Add(new HighScore(data[0], int.Parse(data[1])));
    //         }
            
    //         highScores.Sort();

    //         foreach(HighScore hs in highScores){
    //             string s = hs.date + " - " + hs.score + "\n";
    //             Debug.Log(s);
    //         }
    //     }
    // }
    private void DisplayHighScores()
    {

        highScoresText.text = "High Scores:\n";
        highScoresText.text += TA;
        // List<int> topScores = scoreManager.GetTopScores();  // Updated method name

        // if (topScores != null && topScores.Count > 0)
        // {
            // highScoresText.text = "High Scores:\n";
            // foreach(HighScore hs in highScores){
            //     string s = hs.date + "\t\t" + hs.score + "\n";
            //     highScoresText.text += s;
            //     // Debug.Log(s);
            // }
            // foreach (int score in topScores)
            // {
            //     highScoresText.text += $"{score}\n"=
            // }
        // }
        // else
        // {
        //     highScoresText.text = "No high scores yet.";
        // }
    }
}
