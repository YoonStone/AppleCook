using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateScript : MonoBehaviour {

    GameObject ob;

    private void OnCollisionEnter(Collision coll)
    {
        switch (coll.gameObject.tag)
        {
            case "TARTE1":
                ob = Instantiate(Resources.Load("tarte2") as GameObject);
                ob.transform.position = this.transform.position;
                if (coll.gameObject.transform.parent)
                {
                    coll.gameObject.transform.parent.SendMessage("SameUp", coll.gameObject);
                }
                else
                {
                    Destroy(coll.gameObject);
                }
                Destroy(this.gameObject);
                break;
            case "BREAD":
                ob = Instantiate(Resources.Load("sand1") as GameObject);
                ob.transform.position = this.transform.position;
                if (coll.gameObject.transform.parent)
                {
                    coll.gameObject.transform.parent.SendMessage("SameUp", coll.gameObject);
                }
                else
                {
                    Destroy(coll.gameObject);
                }
                Destroy(this.gameObject);
                break;
            case "WAFFLE1":
                ob = Instantiate(Resources.Load("waffle2") as GameObject);
                ob.transform.position = this.transform.position;
                if (coll.gameObject.transform.parent)
                {
                    coll.gameObject.transform.parent.SendMessage("SameUp", coll.gameObject);
                }
                else
                {
                    Destroy(coll.gameObject);
                }
                Destroy(this.gameObject);
                break;
        } 
    }
}
