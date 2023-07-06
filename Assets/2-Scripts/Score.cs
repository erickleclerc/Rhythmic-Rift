using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score = 0;

    [SerializeField] private TextMeshProUGUI scoreText, highScoreText;
   
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("Score").ToString();

        if (score > PlayerPrefs.GetInt("Score"))
        {
          PlayerPrefs.SetInt("Score", score);
            highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("Score").ToString();
        }
    }
}
