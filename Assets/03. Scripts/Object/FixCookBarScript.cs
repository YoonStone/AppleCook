using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixCookBarScript : MonoBehaviour {


    private void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "COOKBAR")
        {
            transform.rotation = Quaternion.Euler(-90,0,0);
        }       
    }
}
