using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoJuice1Script : MonoBehaviour {

    GameObject ob1, ob2;
    public GameObject part1, part2;
    Animation anim;
    Transform trans;
    bool isAnim;
    AudioSource audioS;

    public float animDelay_time;

    void Start()
    {
        trans = GetComponent<Transform>();
        anim = GetComponent<Animation>();
        audioS = GetComponent<AudioSource>();
        Init();
    }

    private void Update()
    {
        if (trans.rotation.x <= -0.4f)
        {
            part1.SetActive(true);
            part2.SetActive(true);
            Invoke("ReBlender", 3.5f);
        }
        else
        {
            part1.SetActive(false);
            part2.SetActive(false);

        }
    }

    void ReBlender()
    {
        GameObject.FindWithTag("Bottom").SendMessage("RespawnWait");
        GameObject.FindWithTag("Hand").SendMessage("Blender");
        Destroy(this.gameObject);
    }

    void Init()
    {
        anim.Play("Rotate");
        audioS.Play();
        Invoke("AnimDelay", animDelay_time);
    }

    void AnimDelay()
    {
        this.gameObject.tag = "POJUICE1";
    }
}
