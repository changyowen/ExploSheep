using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    public Text ScoreText;
    public int score = 0;

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score : " + score;
    }

    public void AddScore()
    {
        score += 10;
    }
}
