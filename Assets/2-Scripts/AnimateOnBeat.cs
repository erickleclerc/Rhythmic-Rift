using UnityEngine;

public class AnimateOnBeat : MonoBehaviour
{
    public RhythmTiming1 rhythmTimingClass;
    public GameObject childCircleLight;


    void Start()
    {
        GameObject rhythmGO = GameObject.Find("RhythmLogic");

        rhythmTimingClass = rhythmGO.GetComponent<RhythmTiming1>();
    }

    void Update()
    {
        if (rhythmTimingClass.isOnBeat == true)
        {
            childCircleLight.SetActive(true);
        }
        else
        {
            childCircleLight.SetActive(false);
        }
    }
}
