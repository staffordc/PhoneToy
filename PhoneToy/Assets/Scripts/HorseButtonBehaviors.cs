using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseButtonBehaviors : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float screenHeightInUnits = 16f;
    [SerializeField] float minX = 6f;
    [SerializeField] float maxX = 10f;
    [SerializeField] float maxY = 10f;
    [SerializeField] float minY = 6f;
    bool horseClicked = false;
    AudioSource myAudioSource;


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
            HorsePressed();
        }

    }

    private void HorsePressed()
    {
        float[] timings = new float[] { 1.0f, 2.0f, 3.0f, 4.0f, 5.0f };
        if (Input.GetMouseButtonDown(0))
        {
            horseClicked = true;
            AudioClip clip = horseSounds[UnityEngine.Random.Range(0, horseSounds.Length)];
            myAudioSource.PlayOneShot(clip);

        }

    }

}
