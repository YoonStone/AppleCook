using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WitchScript : MonoBehaviour 
{
    public ParticleSystem smoke;
    public float animTime;

    NavMeshAgent navMesh;
    Transform look, target;
    Animator anim;
    GameObject gm;
    AudioSource audio;

    bool isStop;

    void Start () {
        navMesh = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        target = GameObject.FindGameObjectWithTag("WitchPos").GetComponent<Transform>();
        look = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        gm = GameObject.FindGameObjectWithTag("GameController");
        navMesh.SetDestination(target.position);
    }

    void Update () {
        if (isStop)
        {
            transform.LookAt(look.position);
            navMesh.Stop();
            anim.SetBool("IsStop", true);
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        switch (coll.gameObject.tag)
        {
            case "STATIC":
                break;
            case "WitchPos":
                isStop = true;
                Invoke("Delay", 5f);
                break;
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        //한번만 맞으면 바로 죽음
        StartCoroutine("Die");
        //점수 전달
        gm.SendMessage("Love");
    }

    void Delay()
    {
        StartCoroutine("Die");
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(0.5f);
        audio.Play();
        smoke.Play();

        yield return new WaitForSeconds(2f); //파티클시간
        Destroy(this.gameObject);
    }
}
