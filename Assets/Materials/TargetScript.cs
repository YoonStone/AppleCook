using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {

    public ParticleSystem target;
    GameObject dwarf;

    void Play()
    {
        target.Play();
    }
}
