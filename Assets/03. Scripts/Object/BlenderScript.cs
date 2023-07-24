using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlenderScript : MonoBehaviour {

    GameObject target;
    bool isIn;
    
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag != "STATIC")
        {
            if (!isIn)
            {
                switch (coll.gameObject.tag)
                {
                    case "BLENDER":
                    case "JUICE1":
                    case "POJUICE1":
                        target = coll.gameObject; break;
                    default:
                        Invoke("Respawn", 1f);
                        Destroy(coll.gameObject, 1f); break;
                }
            }
        }
    }

    private void OnTriggerStay(Collider coll)
    {
        if (coll.tag != "STATIC")
        {
            isIn = true;
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.tag != "STATIC")
        {
            switch (coll.gameObject.tag)
            {
                case "BLENDER":
                case "JUICE1":
                case "POJUICE1":
                    Invoke("Respawn", 5f);
                    isIn = false;
                    target = null;
                    break;
            }
        }
    }

    void Respawn()
    {
        if (!isIn)
        {
            Instantiate(Resources.Load("blender") as GameObject, this.transform);
            isIn = true;
        }
    }
}
