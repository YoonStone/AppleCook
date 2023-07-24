using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juice1Script : MonoBehaviour {

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
        if (trans.rotation.z <= -0.4f)
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

    // 다시 블렌더로 되돌아오는 코드
    // 이거 대신 주스 다 부으면 블렌더 없어지면서 리스폰으로
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
        this.gameObject.tag = "JUICE1";
    }
}
