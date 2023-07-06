using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.InputSystem;

public class BoxBehaviour : MonoBehaviour
{
    public Score score;
    public RhythmTiming1 rhythmTiming1;
    private bool isOnBeat = false;

    // Start is called before the first frame update
    void Start()
    {
        //score = GameObject.Find("Score").GetComponent<Score>();
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();

        //get the rhythmTiming component and see if the bool isOnBeat is true
        rhythmTiming1 = GameObject.Find("RhythmLogic").GetComponent<RhythmTiming1>();

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroyBox());
        isOnBeat = rhythmTiming1.isOnBeat;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RightHand")
        {
            AddToScoreIfOnBeat();
            Vibrate(InputSystem.GetDevice<XRController>(CommonUsages.RightHand));
        }
        if (other.gameObject.tag == "LeftHand")
        {
            AddToScoreIfOnBeat();
            Vibrate(InputSystem.GetDevice<XRController>(CommonUsages.LeftHand));
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "RightHand")
    //    {
    //        AddToScoreIfOnBeat();
    //        Vibrate(InputSystem.GetDevice<XRController>(CommonUsages.RightHand));
    //    }
    //    if (collision.gameObject.tag == "LeftHand")
    //    {
    //        AddToScoreIfOnBeat();
    //        Vibrate(InputSystem.GetDevice<XRController>(CommonUsages.LeftHand));
    //    }
    //}

    private void AddToScoreIfOnBeat()
    {
        if (isOnBeat == true)
        {
            score.score += 1;
            Destroy(gameObject);
        }
    }

    private static void Vibrate(XRController device)
    {
        var command = UnityEngine.InputSystem.XR.Haptics.SendHapticImpulseCommand.Create(0, 1, 0.1f);
        device.ExecuteCommand(ref command);
        //Debug.Log(device.name);
    }

    IEnumerator DestroyBox()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
