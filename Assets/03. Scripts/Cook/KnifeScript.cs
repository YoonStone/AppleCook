using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour {

    GameObject ob1, ob2;

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "WAFFLE2")
        {
            ob1 = Instantiate(Resources.Load("waffle") as GameObject);
            ob1.transform.position = coll.gameObject.transform.position;
            if (this.transform.parent)
            {
                this.transform.parent.SendMessage("SameUp", this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.tag == "COOKBAR")
        {
            Destroy(this.gameObject);
        }
    }
}
