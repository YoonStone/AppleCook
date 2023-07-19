using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour {
    
    public float EndTime = 300.0f;

    AudioSource audioS;

    void Start () {
        audioS = GetComponent<AudioSource>();
        audioS.Play();
        StartCoroutine("GameEndShow");
    }

    IEnumerator GameEndShow()
    {
        yield return new WaitForSeconds(EndTime);
        audioS.Stop();
    }
}
