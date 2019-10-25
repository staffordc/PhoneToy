using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class RecordButtonBehavior : MonoBehaviour
{
    IEnumerator ListenWell = null;
    void Start()
    {

    }
    public List<float> SoundList_ener = new List<float>();
    public void Recording()
    {
        if (ListenWell == null)
        {
            ListenWell = ListenVeryGood();
            StartCoroutine(ListenWell);
        }

    }
    IEnumerator ListenVeryGood()
    {
        FindObjectOfType<PlayButtonBehaviors>().Disable();
        var loops = 0;
        var timeElapsed = 0f;
        SoundList_ener = new List<float>();

        while (timeElapsed <= 5f)
        {
            timeElapsed += Time.deltaTime;
            if (Input.GetMouseButtonDown(0))//mouse input check if it's been clicked add it to SLener
            {
                //Debug.Log(timestamps of mouse 0)
                Debug.Log("Loops around " + loops);
                loops += 1;
                //timestamp to list.add to SLener
                SoundList_ener.Add(timeElapsed);
                //Debug.Log(SLener)
                Debug.Log("List contents");
                Debug.Log(string.Join(", ", SoundList_ener));
                //SoundList_ener.ForEach(t => Debug.Log(t));
                //How does the play button access this???
            }
            yield return null;
        }

        ListenWell = null;
        FindObjectOfType<PlayButtonBehaviors>().Enable(SoundList_ener);
    }
}