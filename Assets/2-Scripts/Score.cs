using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score = 0;

    [SerializeField] private TextMeshPro scoreText;


    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
