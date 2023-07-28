using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.VFX;

public class CheckBoxOnBeat : MonoBehaviour
{
    public GameObject showOnBeatText;
    private GameObject t;

    private Vector3 textPosition;

    public RhythmTiming1 rhythmTiming1;
    private bool isOnBeat = false;
    private bool gotMissed = false;
    private bool playerHit = false;

    // Start is called before the first frame update
    void Start()
    {
        //get the rhythmTiming component and see if the bool isOnBeat is true
        rhythmTiming1 = GameObject.Find("RhythmLogic").GetComponent<RhythmTiming1>();

        textPosition = transform.position;
        textPosition.z = 1;

        t = Instantiate(showOnBeatText, textPosition, Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        isOnBeat = rhythmTiming1.isOnBeat;

        if (transform.position.z < -1.021 && gotMissed == false)
        {
            gotMissed = true;
            ShowIfMissHitText();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerHit == false) 
        {
            if (other.gameObject.tag == "RightHand" && transform.position.z >= -1.021)
            {
                ShowIfOnBeatText();
                
            }
            if (other.gameObject.tag == "LeftHand" && transform.position.z >= -1.021)
            {
                ShowIfOnBeatText();
            }

            playerHit = true;
        }
        
    }

    private void ShowIfOnBeatText()
    {
        if (isOnBeat == true)
        {
            t.transform.GetChild(0).gameObject.SetActive(true);
            StartCoroutine(DestoryText(t));
        }

        if (isOnBeat == false)
        {
            t.transform.GetChild(1).gameObject.SetActive(true);
            StartCoroutine(DestoryText(t));
        }
    }

    private void ShowIfMissHitText()
    { 
        if(gotMissed == true && playerHit == false)
        {
            t.transform.GetChild(2).gameObject.SetActive(true);
            StartCoroutine(DestoryText(t));
        }
    }

    IEnumerator DestoryText(GameObject text)
    {
        yield return new WaitForSeconds(0.5f);

        if (text != null)
        {
            text.GetComponent<RemoveTextBox>().DestroySelf();
        }

    }
}
