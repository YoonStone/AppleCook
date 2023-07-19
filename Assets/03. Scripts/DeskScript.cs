using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskScript : MonoBehaviour {

    bool isThere;
    GameObject target;

    private void OnCollisionEnter(Collision coll)
    {
        switch (coll.gameObject.tag)
        {
            case "STATIC":
            case "COOKBAR":
            case "MASSTARTE":
            case "MASSBREAD":
            case "MASSWAFFLE":
            case "MASSAPPLE":
            case "JAM":
            case "BLENDER":
            case "JUICE1":
            case "CUP":
            case "JUICE":
                break;
            default:
                target = coll.gameObject;
                Invoke("Destroy", 2f);
                isThere = true; break;
        }
    }

    private void OnCollisionExit(Collision coll)
    {
        if(coll.gameObject == target)
        {
            isThere = false;
        }
    }

    void Destroy()
    {
        if (isThere)
        {
            Destroy(target);
        }
    }
}
