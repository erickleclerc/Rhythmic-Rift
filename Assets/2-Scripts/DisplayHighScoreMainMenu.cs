using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHighScoreMainMenu : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("Score");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
