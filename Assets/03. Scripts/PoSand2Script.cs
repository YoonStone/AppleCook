using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoSand2Script : MonoBehaviour {

    GameObject ob;

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "BREAD")
        {
            ob = Instantiate(Resources.Load("posand") as GameObject);
            ob.transform.position = this.transform.position;
            if (coll.gameObject.transform.parent)
            {
                coll.gameObject.transform.parent.SendMessage("SameUp", coll.gameObject.gameObject);
            }
            else
            {
                Destroy(coll.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
