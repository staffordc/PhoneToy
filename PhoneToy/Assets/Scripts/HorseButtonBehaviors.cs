using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class HorseButtonBehaviors : MonoBehaviour
{

    AudioSource myAudioSource;
    IEnumerator randomPlay = null;
    [SerializeField] AudioClip[] horseSounds;
    List<float> SoundList_ener = new List<float>();

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

    public IEnumerator ListenVeryGood()
    {
        FindObjectOfType<PlayButtonBehaviors>().Disable();
        var timeElapsed = 0f;
        SoundList_ener = new List<float>();

        while (timeElapsed <= 5f)
        {
            GameObject.Find("BarOfProgress").GetComponent<RectTransform>().localScale = new Vector3(timeElapsed / 5f, 1f, 1f);
            timeElapsed += Time.deltaTime;
            if (Input.GetMouseButtonDown(0))//mouse input check if it's been clicked add it to SLener
            {
                //timestamp to list.add to SLener
                SoundList_ener.Add(timeElapsed);
            }
            yield return null;
            GameObject.Find("BarOfProgress").GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        }

        FindObjectOfType<RecordButtonBehavior>().ListenWell = null;
        FindObjectOfType<PlayButtonBehaviors>().Enable(SoundList_ener);
    }
}
