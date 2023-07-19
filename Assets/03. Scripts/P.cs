using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//접시 리스폰
public class P : MonoBehaviour {

    GameObject target;
    bool isIn;

    //5초마다 체크해서 비어있으면 리스폰 *오류
    /*private void Start()
    {
        InvokeRepeating("Respawn", 10f, 5f);
    }*/

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.tag != "STATIC")
        {
            if (!isIn)
            {
                target = coll.gameObject;
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
                case "TARTE":
                case "TARTE2":
                case "TARTE3":
                case "TARTEB":
                case "POTARTE":
                case "POTARTE3":
                case "POSAND":
                case "POSAND2":
                case "SAND":
                case "SAND1":
                case "SAND2":
                case "WAFFLE":
                case "WAFFLE2":
                    Invoke("Respawn", 3f);
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
            Instantiate(Resources.Load("plate") as GameObject, this.transform);
            isIn = true;
        }
    }
}