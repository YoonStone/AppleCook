using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//접시 리스폰
public class C : MonoBehaviour
{
    GameObject target;
    bool isIn;

    //5초마다 체크해서 비어있으면 리스폰 *오류
    private void Start()
    {
        //InvokeRepeating("Respawn", 10f, 5f);
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag != "STATIC")
        {
            if (!isIn)
            {
                switch (coll.gameObject.tag)
                {
                    case "JUICE":
                    case "POJUICE":
                    case "CUP":
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
        switch (coll.gameObject.tag)
        {
            case "JUICE":
            case "POJUICE":
                Invoke("Respawn", 3f);
                isIn = false;
                target = null;
                break;
        }
    }

    void Respawn()
    {
        if (!isIn)
        {
            Instantiate(Resources.Load("cup") as GameObject, this.transform);
            isIn = true;
        }
    }
}