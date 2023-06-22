using System.Collections;
using UnityEngine;

public class BeatPulse : MonoBehaviour
{
    [SerializeField] bool useTestBeat;
    [SerializeField] float pulseSize = 1.2f;
    [SerializeField] float returnSpeed = 5f;
    [SerializeField] Vector3 startSize;

    private bool isPulsating = false;

    private void Start()
    {
        startSize = transform.localScale;
        if (useTestBeat)
        {
            StartCoroutine(TestBeat());
        }
    }

    private void Update()
    {
        if (!isPulsating)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, startSize, Time.deltaTime * returnSpeed);
        }
    }

    IEnumerator TestBeat()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Pulsate();
        }
    }

    public void Pulsate()
    {
        if (!isPulsating)
        {
            StartCoroutine(PulseAnimation());
        }
    }

    IEnumerator PulseAnimation()
    {
        isPulsating = true;
        transform.localScale = startSize * pulseSize;

        yield return new WaitForSeconds(0.2f);

        transform.localScale = startSize;
        isPulsating = false;
    }
}
