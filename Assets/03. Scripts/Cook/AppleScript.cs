using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
 {
    GameObject ob;

    private void OnCollisionEnter(Collision coll)
    {
        switch (coll.gameObject.tag)
        {
            case "TARTE2":
                ob = Instantiate(Resources.Load("tarte3") as GameObject);
                ob.transform.position = coll.gameObject.transform.position;
                if (this.transform.parent)
                {
                    this.transform.parent.SendMessage("SameUp", this.gameObject);
                }
                else
                {
                    Destroy(this.gameObject);
                }
                Destroy(coll.gameObject);
                break;
            case "BLENDER":
                ob = Instantiate(Resources.Load("juice1") as GameObject);
                ob.transform.position = coll.gameObject.transform.position;
                if (this.transform.parent)
                {
                    this.transform.parent.SendMessage("SameUp", this.gameObject);
                }
                else
                {
                    Destroy(this.gameObject);
                }
                Destroy(coll.gameObject);
                break;
            case "SAND1":
                ob = Instantiate(Resources.Load("sand2") as GameObject);
                ob.transform.position = coll.gameObject.transform.position;
                if (this.transform.parent)
                {
                    this.transform.parent.SendMessage("SameUp", this.gameObject);
                }
                else
                {
                    Destroy(this.gameObject);
                }
                Destroy(coll.gameObject);
                break;
        }
    }
}
