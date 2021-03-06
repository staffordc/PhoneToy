using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayButtonBehaviors : MonoBehaviour
{
    AudioSource myAudioSource;
    IEnumerator randomPlay = null;
    [SerializeField] AudioClip[] playSounds;
    List<float> myRecordTimes;
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    public void Enable(List<float> recordTimes)
    {
        GetComponent<Button>().enabled = true;
        myRecordTimes = recordTimes;
    }
    public void Disable()
    {
        GetComponent<Button>().enabled = false;
    }
    public void FirstPlay()
    {
        if (myRecordTimes == null)
        {
            randomPlay = DoRandomPlay();
            StartCoroutine(randomPlay);
        }
        else
        {
            var doTimePlay = DoTimePlay();
            StartCoroutine(doTimePlay);
        }

    }
    IEnumerator DoTimePlay()
    {
        var timeElapsede = 0f;

        timeElapsede += Time.deltaTime;
        foreach (var r in myRecordTimes)
        {
            while (r > timeElapsede)
            {
                timeElapsede += Time.deltaTime;
                GameObject.Find("BarOfProgress").GetComponent<RectTransform>().localScale = new Vector3(timeElapsede / 5f, 1f, 1f);
                yield return new WaitForEndOfFrame();
                Debug.Log(r);
            }
            AudioClip clip = playSounds[UnityEngine.Random.Range(0, playSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            Debug.Log(r);
        }
        yield return null;
        GameObject.Find("BarOfProgress").GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
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
            GameObject.Find("BarOfProgress").GetComponent<RectTransform>().localScale = new Vector3(timeElapsed / 5f, 1f, 1f);
            if (timeElapsed > loopRan)
            {
                AudioClip clip = playSounds[UnityEngine.Random.Range(0, playSounds.Length)];
                myAudioSource.PlayOneShot(clip);
                randomFrameHit = UnityEngine.Random.Range(0f, 1.5f);
                loopRan += randomFrameHit;
            }

            yield return new WaitForEndOfFrame();
        }
        GameObject.Find("BarOfProgress").GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        randomPlay = null;

    }
}