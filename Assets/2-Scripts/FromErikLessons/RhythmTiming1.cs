using UnityEngine;

public class RhythmTiming1 : MonoBehaviour
{
    //public GameObject movingTarget;

   // public GameObject target;
    public AudioSource songSource;

    public bool isOnBeat = false;

    //public TextMeshProUGUI timeText;
    
    public int BPM = 96;

    private int previousBeat = -1;
    private double audioStartTime;

    // => this arrow shows that this is a "property". It basically is a function pretending to be a variable.
    private double elapsedAudioTime => AudioSettings.dspTime - audioStartTime;
    private float elapsedTimeMinutes => (float)(elapsedAudioTime / 60);
    public int currentBeat => Mathf.FloorToInt(elapsedTimeMinutes * BPM);

    private void Start()
    {

        songSource = GameObject.Find("VRRig").gameObject.GetComponent<AudioSource>();

        // DSP = "digital signal processing"
        double currentAudioTime = AudioSettings.dspTime;
        audioStartTime = (float)currentAudioTime + 3;

        songSource.PlayScheduled(audioStartTime);

    }

    private void Update()
    {

        // How much audio time has elapsed since we requested the audio source to play?
        double time = elapsedAudioTime;

        // Convert it from seconds to minutes, e.g., 30 seconds = 0.5 minutes.
        // float toMinutes = elapsedTimeMinutes;

        // Convert from seconds to beat, rounding down (e.g., 45.67 seconds = beat 45 at 60 bpm).
        int beat = currentBeat;

        if (previousBeat != beat)
        {
           //target.GetComponent<Renderer>().material.color = beat % 2 != 0 ? Color.red : Color.blue;

            isOnBeat = beat % 2 != 0 ? true : false;

            previousBeat = beat;
        }

        Debug.Log($"Is on beat: {isOnBeat}");

        UpdateMovingTarget();

        string output = $"Time: <b>{time:00:00.00}</b> Beat: <b>{beat:000}</b>";

        //timeText.text = output;
    }

    private bool haveSpawnedObject = false;
    private bool hasArrived;
    private double spawnTime;

    [Header("Moving Settings")]
    public float distance = 10;
    public float time = 2;

    private void UpdateMovingTarget()
    {
        if (currentBeat == 0 && haveSpawnedObject == false)
        {
            //transform.position = new Vector3(0, 2, distance);
            spawnTime = elapsedAudioTime;

            haveSpawnedObject = true;
        }

        if (currentBeat >= 0)
        {
            //transform.position += Vector3.back * (distance / time) * Time.deltaTime;

            if (hasArrived == false && transform.position.x <= 0)
            {
                double duration = elapsedAudioTime - spawnTime;

                Debug.Log($"It took: {duration} Expected: {time}");

                hasArrived = true;
            }
        }
    }
}

