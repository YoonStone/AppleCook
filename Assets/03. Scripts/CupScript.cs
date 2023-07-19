using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupScript : MonoBehaviour {


    void OnParticleCollision(GameObject coll)
    {
        if (coll.gameObject.tag == "Juice_")
        {
            Invoke("BeJuice", 3f);
        }
        else if(coll.gameObject.tag == "POJuice_")
        {
            Invoke("BePOJuice", 3f);

        }
    }

    void BeJuice()
    {
        Destroy(this.gameObject);
        GameObject ob = Instantiate(Resources.Load("juice") as GameObject);
        ob.transform.position = this.transform.position;
    }

    void BePOJuice()
    {
        Destroy(this.gameObject);
        GameObject ob = Instantiate(Resources.Load("pojuice") as GameObject);
        ob.transform.position = this.transform.position;
    }
}
