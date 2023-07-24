using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

    AudioSource audio;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        audio.Play();
        Invoke("End", 20f);
    }

    void End()
    {
        SceneManager.LoadScene(1); //시작
    }
}
