using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 타르트 = 1
// 주스 = 2
// 샌드위치 = 3
// 와플 = 4
public class DwarfScript : MonoBehaviour {
    
    public Image tarte, juice, waffle, sandwitch;
    public Canvas orderCanvas;
    public ParticleSystem likeparticle, lefthateparticle, righthateparticle, poPaticle;
    Transform look;
    
    int order;
    int chair;
    int maxDish = 4;

    bool isEnd = false;
    bool isWalk = true;
    bool isStop, isIdle, isEat, isLike, isHate;
    
    enum DwarfState
    {
        Idle,
        Walk,
        Eat,
        Like,
        Hate
    }

    DwarfState mState;

    Animator anim;

    private void Start()
    {
        order = Random.Range(1, 5);
        anim = GetComponent<Animator>();
        mState = DwarfState.Walk;
        look = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        switch (mState)
        {
            case DwarfState.Idle:
                Idle();
                break;
            case DwarfState.Walk:
                Walk();
                break;
            case DwarfState.Like:
                Like();
                break;
            case DwarfState.Hate:
                Hate();
                break;
            case DwarfState.Eat:
                Eat();
                break;
        }

        if (isIdle)
        {
            print("바라보기");
            transform.LookAt(look.position);
        }
    }

    void Idle()
    {
        anim.SetBool("IsStop", true);
        print("바라보기");

        isIdle = true;
    }

    void Walk()
    {
        anim.SetBool("IsStop", false);
        anim.SetBool("IsEat", false);
        isIdle = false;
    }

    void Eat()
    {
        anim.SetBool("IsEat", true);
        isIdle = true;
    }

    void Like()
    {
        anim.SetBool("IsLike", true);
        anim.SetBool("IsHate", false);
        isIdle = true;
    }

    void Hate()
    {
        anim.SetBool("IsHate", true);
        anim.SetBool("IsLike", false);
        isIdle = true;
    }

    void IsEnd()
    {
        isEnd = true;
    }

    void End()
    {
        StartCoroutine("TheEnd");
    }

    void Stop()
    {
        Destroy(this.gameObject);
    }

    //닿았을 때
    private void OnTriggerEnter(Collider coll)
    {
        for (int i = 1; i <= maxDish; i++)
        {
            if (coll.tag == "TARGET"+i)
            {
                chair = i;
                Invoke("OrderStart", 1f);
                StartCoroutine("OrderStart");
                GameObject.FindGameObjectWithTag("Dish"+i).SendMessage("DwarfStart");
                isStop = true;
                isWalk = false;
            }
        }
    }

    //주문 시작
    void OrderStart()
    {
        switch (order)
        {
            case 1:
                tarte.gameObject.SetActive(true);
                break;
            case 2:
                juice.gameObject.SetActive(true);
                break;
            case 3:
                sandwitch.gameObject.SetActive(true);
                break;
            case 4:
                waffle.gameObject.SetActive(true);
                break;
        }
    }

    //음식이 식탁에 닿았을 때
    void OnTouch()
    {
        for (int i = 1; i <= maxDish; i++)
        {
            if (chair == i)
            {
                switch (order)
                {
                    case 1:
                        GameObject.FindGameObjectWithTag("Dish" + i).SendMessage("OnTarteStart");
                        break;
                    case 2:
                        GameObject.FindGameObjectWithTag("Dish" + i).SendMessage("OnJuiceStart");
                        break;
                    case 3:
                        GameObject.FindGameObjectWithTag("Dish" + i).SendMessage("OnSandWichStart");
                        break;
                    case 4:
                        GameObject.FindGameObjectWithTag("Dish" + i).SendMessage("OnWaffleStart");
                        break;
                }
            }
            mState = DwarfState.Eat;
        }
    }

    //맞는 음식일 때 + dish한테서 옴
    void OnLove()
    {
        if (!isEnd)
        {
            if (orderCanvas == null)
                print("No Canvas");
            else
                Destroy(orderCanvas.gameObject);

            likeparticle.Play();
            Invoke("Like", 1f);
            Destroy(this.gameObject, 2f);

            GameObject.FindGameObjectWithTag("GameController").SendMessage("Love");
        }
    }

    //안 맞는 음식일 때 + dish한테서 옴
    void OnHate()
    {
        if (orderCanvas == null)
            print("No Canvas");
        else
            Destroy(orderCanvas.gameObject);

        lefthateparticle.Play();
        righthateparticle.Play();
        Invoke("Hate", 1f);

        isEnd = true;
        Destroy(this.gameObject, 2f);
        
        GameObject.FindGameObjectWithTag("GameController").SendMessage("Hate");
    }

    //독이 든 음식일 때 + dish한테서 옴
    void OnPoison()
    {
        if (orderCanvas == null)
            print("No Canvas");
        else
            Destroy(orderCanvas.gameObject);

        lefthateparticle.Play();
        righthateparticle.Play();
        poPaticle.Play();
        Invoke("Hate", 1f);

        isEnd = true;
        Destroy(this.gameObject, 2f);

        GameObject.FindGameObjectWithTag("GameController").SendMessage("Hate");
    }
}