using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehaviour : MonoBehaviour
{
    public Score score;
    private RhythmTiming1 rhythmTiming1;
    private bool isOnBeat = false;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score").GetComponent<Score>();

        //get the rhythmTiming component and see if the bool isOnBeat is true
        rhythmTiming1 = GameObject.Find("RhythmLogic").GetComponent<RhythmTiming1>();

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroyBox());
        isOnBeat = rhythmTiming1.isOnBeat;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hand")
        {
            if (isOnBeat == true)
            {
                score.score += 1;
                Destroy(gameObject);
            }
        }
    }


    IEnumerator DestroyBox()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
