using UnityEngine;
using System.Collections;

public class HorseButtonBehaviors : MonoBehaviour
{
    bool horseClicked = false;
    AudioSource myAudioSource;
    IEnumerator CurrentSequence = null;

    [SerializeField] AudioClip[] horseSounds;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Got to the Get MouseButtonDown" + gameObject.name);


            Debug.Log("Got to the check for null" + gameObject.name);
            horseClicked = true;
            Debug.Log("HorseClicked is true now");
            CurrentSequence = DoSequence();
            Debug.Log("DoSequence is assigned to Current Sequence");
            StartCoroutine(CurrentSequence);
            Debug.Log("CurrentSequence was run");
        }

    }

    // private void HorsePressed()
    // {
    //     float[] timings = new float[] { 1.0f, 2.0f, 3.0f, 4.0f, 5.0f };
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         horseClicked = true;
    //         AudioClip clip = horseSounds[UnityEngine.Random.Range(0, horseSounds.Length)];
    //         myAudioSource.PlayOneShot(clip);

    //     }

    // }

    IEnumerator DoSequence()
    {
        //randomFrameHit is what it is on first play, Recording next
        var randomFrameHit = 1.0f;
        var loopRan = 0f;
        var timeElapsed = 0f;
        while (timeElapsed <= 5f)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > loopRan)
            {
                AudioClip clip = horseSounds[UnityEngine.Random.Range(0, horseSounds.Length)];
                myAudioSource.PlayOneShot(clip);
                randomFrameHit = UnityEngine.Random.Range(0f, 1.5f);
                loopRan += randomFrameHit;
                Debug.Log("active thing you're watching " + loopRan);
            }

            yield return new WaitForEndOfFrame();
        }

        CurrentSequence = null;
        horseClicked = false;
    }
}
