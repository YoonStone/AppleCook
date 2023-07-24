using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenScript : MonoBehaviour {

    public GameObject ovenLight;

    private bool isThere, isStillThere, isTarte;
    GameObject tarte, tarteB;
    AudioSource audioS;
    Animation anim;

    float ovenTime = 3f;
    float burnTime = 5f;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
        anim = GetComponentInChildren<Animation>();
    }

    private void OnCollisionEnter(Collision coll)
    {
        switch (coll.gameObject.tag)
        {
            case "TARTE3":
                if (!isTarte)
                {
                    StartCoroutine("StartCook", coll.gameObject);
                    StartCoroutine("LightOn");
                    isTarte = true;
                }
                break;

            case "POTARTE3":
                if (!isTarte)
                {
                    StartCoroutine("StartPoCook", coll.gameObject);
                    StartCoroutine("LightOn");
                    isTarte = true;
                }
                break;

            case "TARTE":
            case "POTARTE":
                StartCoroutine("StartBurn", coll.gameObject);
                StartCoroutine("LightOff");
                break;
            default:
                //Destroy(coll.gameObject, 1f); 
                break;
        }
    }
    
    //닿아있는 중
    private void OnCollisionStay(Collision coll)
    {
        switch (coll.gameObject.tag)
        {
            case "TARTE3":
            case "POTARTE3":
                isThere = true;
                break;

            case "TARTE":
            case "POTARTE":
                isStillThere = true;
                break;
        }
    }

    //떨어졌을 때
    private void OnCollisionExit(Collision coll)
    {
        switch (coll.gameObject.tag)
        {
            case "TARTE3":
            case "POTARTE3":
                isThere = false;
                break;

            case "TARTE":
            case "POTARTE":
                isStillThere = false;
                break;
        }
    }

    //닫히고 불
    IEnumerator LightOn()
    {
        print("문닫힘");
        anim.Play("oven_close");
        yield return new WaitForSeconds(0.5f);
        ovenLight.SetActive(true);
    }

    //열리고 불꺼짐
    IEnumerator LightOff()
    {
        anim.Play("oven_open");
        yield return new WaitForSeconds(0.5f);
        ovenLight.SetActive(false);
        isTarte = false;
    }

    //요리 시작
    IEnumerator StartCook(GameObject coll)
    {
        yield return new WaitForSeconds(ovenTime);
        if (isThere)
        {
            tarte = Instantiate(Resources.Load("tarte") as GameObject);
            audioS.Play();
            if (coll != null)
            {
                tarte.transform.position = coll.transform.position;
                Destroy(coll);
            }
            else
            {
                Destroy(tarte);
                StartCoroutine("LightOff");
            }
        }
        else
        {
            StartCoroutine("LightOff");
        }
    }

    //요리 시작(독)
    IEnumerator StartPoCook(GameObject coll)
    {
        yield return new WaitForSeconds(ovenTime);
        if (isThere)
        {
            tarte = Instantiate(Resources.Load("potarte") as GameObject);
            audioS.Play();
            if (coll != null)
            {
                tarte.transform.position = coll.transform.position;
                Destroy(coll);
            }
            else
            {
                Destroy(tarte);
                StartCoroutine("LightOff");
            }
        }
        else
        {
            StartCoroutine("LightOff");
        }
    }

    //타기 시작
    IEnumerator StartBurn(GameObject tarte)
    {
        yield return new WaitForSeconds(burnTime);
        if (isStillThere)
        {
            tarteB = Instantiate(Resources.Load("tarteB") as GameObject);
            tarteB.transform.position = tarte.transform.position;
            Destroy(tarte);
        }
    }
}
