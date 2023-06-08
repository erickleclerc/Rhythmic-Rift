using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BPMChecker : MonoBehaviour
{
    [SerializeField] private RhythmTiming1 rhythmTiming1;
    
    [Header("Moving Settings")]
    public float distance = 10;
    public float time = 2;


    private void Awake()
    {
       rhythmTiming1 = GameObject.Find("RhythmLogic").GetComponent<RhythmTiming1>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rhythmTiming1.currentBeat >= 0)
        {
            transform.position += Vector3.back * (distance / time) * Time.deltaTime;
        }
    }
}
