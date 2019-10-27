using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class RecordButtonBehavior : MonoBehaviour
{
    public IEnumerator ListenWell = null;
    void Start()
    {

    }
    public List<float> SoundList_ener = new List<float>();
    public void Recording()
    {
        if (ListenWell == null)
        {
            ListenWell = FindObjectOfType<HorseButtonBehaviors>().ListenVeryGood();
            SoundList_ener = new List<float>();
            StartCoroutine(ListenWell);
        }

    }

}