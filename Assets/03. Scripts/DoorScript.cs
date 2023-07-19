using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    Animation anim;

    private void Start()
    {
        anim = GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider coll)
    {
        anim.Play("door");
    }
}