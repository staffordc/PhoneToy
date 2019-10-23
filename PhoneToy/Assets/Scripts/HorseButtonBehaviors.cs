using UnityEngine;
using System.Collections;

public class HorseButtonBehaviors : MonoBehaviour
{
    bool horseClicked = false;
    AudioSource myAudioSource;
    IEnumerator randomPlay = null;
    [SerializeField] AudioClip[] horseSounds;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    public void HorsePressed()
    {
        horseClicked = true;
        AudioClip clip = horseSounds[UnityEngine.Random.Range(0, horseSounds.Length)];
        myAudioSource.PlayOneShot(clip);
    }

    // IEnumerator DoRandomPlay()
    // {
    //     //randomFrameHit is what it is on first play
    //     var randomFrameHit = 1.0f;
    //     var loopRan = 0f;
    //     var timeElapsed = 0f;
    //     while (timeElapsed <= 5f)
    //     {
    //         timeElapsed += Time.deltaTime;
    //         if (timeElapsed > loopRan)
    //         {
    //             AudioClip clip = horseSounds[UnityEngine.Random.Range(0, horseSounds.Length)];
    //             myAudioSource.PlayOneShot(clip);
    //             randomFrameHit = UnityEngine.Random.Range(0f, 1.5f);
    //             loopRan += randomFrameHit;
    //             Debug.Log("active thing you're watching " + loopRan);
    //         }

    //         yield return new WaitForEndOfFrame();
    //     }

    //     randomPlay = null;
    //     horseClicked = false;
    // }
}
