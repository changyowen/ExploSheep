using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    public int HighScore;
    public Text ScoreText;
    public Text GameOverScore;
    public int score = 0;
    public Text HighScoreText;

    // Update is called once per frame
    void Start()
    {
        HighScore = PlayerPrefs.GetInt("HighScore");
    }
    void Update()
    {
        ScoreText.text = "Score : " + score;
        GameOverScore.text = "Score :" + score;
        if (score > HighScore)
        {
            HighScore = score;

        }

        HighScoreText.text = "High score : " + HighScore;
        PlayerPrefs.SetInt("HighScore", HighScore);
    }

    public void AddScore()
    {
        score += 10;
    }
}
