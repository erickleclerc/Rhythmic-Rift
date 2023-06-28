using UnityEngine;
using UnityEngine.Events;

public class BeatManager : MonoBehaviour
{
    // add varying pulse effects on beats and half beats
    [SerializeField] private float bpm;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Intervals[] intervals;

    //note depending on graphics card, shader manipulation might not be supported
    [SerializeField] private Renderer indicatorRenderer;
    [SerializeField] private string shaderPropertyName = "_Amount"; 

    


    private double audioStartTime;
    private int previousBeat = -1;
    private int BPMcount = 60;

    private double elapsedAudioTime => AudioSettings.dspTime - audioStartTime;
    private float elapsedTimeMinutes => (float)(elapsedAudioTime / BPMcount);
    private int currentBeat => Mathf.FloorToInt(elapsedTimeMinutes * BPMcount);

    private void Start()
    {
        double currentAudioTime = AudioSettings.dspTime;
        audioStartTime = currentAudioTime + 2;
        audioSource.PlayScheduled(audioStartTime);
    }

    private void Update()
    {
        double time = elapsedAudioTime;
        int beat = currentBeat;
        float amount = 0.5f;

        if (previousBeat != beat)
        {
            // testing dissolve effect on shader
            float shaderAmount = beat % 2 != 0 ? amount : 0f;
            indicatorRenderer.material.SetFloat(shaderPropertyName, shaderAmount);
            previousBeat = beat;

            //test to affect skybox, be careful flashing lights may cause seizure
            //float exposure = beat % 2 != 0 ? .3f : .75f;
            //RenderSettings.skybox.SetFloat("_Exposure", exposure);
            
        }

        foreach (Intervals interval in intervals)
        {
            float sampledTime = audioSource.timeSamples / (audioSource.clip.frequency * interval.GetIntervalLength(bpm));
            interval.CheckForNewInterval(sampledTime);
        }
    }
}

[System.Serializable]
public class Intervals
{
    [SerializeField] private float steps;
    [SerializeField] private UnityEvent beatPulseTrigger;
    private int lastInterval;

    public float GetIntervalLength(float bpm)
    {
        return 60f / (steps * bpm);
    }

    public void CheckForNewInterval(float interval)
    {
        if (Mathf.FloorToInt(interval) != lastInterval)
        {
            lastInterval = Mathf.FloorToInt(interval);
            beatPulseTrigger.Invoke();
        }
    }
}
