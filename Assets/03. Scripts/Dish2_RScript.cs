using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish2_RScript : MonoBehaviour {

    string food;
    public GameObject next, o, x, play;

    private void OnCollisionEnter(Collision coll)
    {
        print(coll.gameObject.tag);
        if (food == coll.gameObject.tag)
        {
            o.gameObject.SetActive(true);
            Invoke("Destroy", 1f);
            Destroy(coll.gameObject, 0.5f);
            if (food == "JUICE")
            {
                play.gameObject.SetActive(true);
            }
            else
            {
                next.gameObject.SetActive(true);
            }
        }
        else
        {
            x.gameObject.SetActive(true);
            Invoke("Destroy", 1f);
            Destroy(coll.gameObject, 0.5f);
        }
    }

    private void Destroy()
    {
        o.gameObject.SetActive(false);
        x.gameObject.SetActive(false);
    }

    //음식 이름 받아오기
    void Send(string foodName)
    {
        food = foodName;
    }
}
