using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosionScript : MonoBehaviour {

    public ParticleSystem poPaticle;

    void Poison()
    {
        if (poPaticle)
        {
            poPaticle.Play();
        }
    }
}
