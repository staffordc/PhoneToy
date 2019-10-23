using UnityEngine;
using System.Collections;


public class PlayButtonBehaviors : MonoBehaviour
{
    bool playButtonPressed = false;
    AudioSource myAudioSource;
    IEnumerator randomPlay = null;
    [SerializeField] AudioClip[] playSounds;
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    //void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         if (playButtonPressed == false)
    //         
    //     }

    // }
    public void NotUpdate()
    {
        randomPlay = DoRandomPlay();
        StartCoroutine(randomPlay);
    }
    IEnumerator DoRandomPlay()
    {
        //randomFrameHit is what it is on first play
        var randomFrameHit = 1.0f;
        var loopRan = 0f;
        var timeElapsed = 0f;
        while (timeElapsed <= 5f)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > loopRan)
            {
                AudioClip clip = playSounds[UnityEngine.Random.Range(0, playSounds.Length)];
                myAudioSource.PlayOneShot(clip);
                randomFrameHit = UnityEngine.Random.Range(0f, 1.5f);
                loopRan += randomFrameHit;
                Debug.Log("active thing you're watching " + loopRan);
            }

            yield return new WaitForEndOfFrame();
        }

        randomPlay = null;
        playButtonPressed = false;

    }
}