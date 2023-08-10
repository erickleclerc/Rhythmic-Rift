using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.InputSystem;

public class BoxBehaviour : MonoBehaviour
{
    public Score score;
    public RhythmTiming1 rhythmTiming1;
    private bool isOnBeat = false;

    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();

        rhythmTiming1 = GameObject.Find("RhythmLogic").GetComponent<RhythmTiming1>();
    }

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
