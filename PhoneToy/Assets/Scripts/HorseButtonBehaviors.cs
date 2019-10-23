using UnityEngine;
using System.Collections;

public class HorseButtonBehaviors : MonoBehaviour
{
    AudioSource myAudioSource;
    IEnumerator randomPlay = null;
    [SerializeField] AudioClip[] horseSounds;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    public void HorsePressed()
    {
        AudioClip clip = horseSounds[UnityEngine.Random.Range(0, horseSounds.Length)];
        myAudioSource.PlayOneShot(clip);
    }
}
