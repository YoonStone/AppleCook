using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 타르트 = 1
// 주스 = 2
// 샌드위치 = 3
// 와플 = 4
public class DwarfScript_ex : MonoBehaviour {
    
    public Image tarte, juice, waffle, sandwitch;
    public Canvas orderCanvas;
    public ParticleSystem likeparticle, lefthateparticle, righthateparticle, poPaticle;
    
    int order;
    int chair;
    int maxDish = 4;

    bool isEnd = false;
    bool isWalk = true;
    bool isStop, isEat, isLike, isHate;

    Transform look;
    Animator anim;

    private void Start()
    {
        order = Random.Range(1, 5);
        anim = GetComponent<Animator>();
        look = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (isWalk)
        {
            Walk();
        } else if (isStop)
        {
            Idle();
            transform.LookAt(look.position);
        }
        else if (isEat)
        {
            Eat();
        }
    }

    void Idle()
    {
        anim.SetBool("IsStop", true);
    }

    void Walk()
    {
        anim.SetBool("IsStop", false);
        anim.SetBool("IsEat", false);
    }

    void Eat()
    {
        anim.SetBool("IsEat", true);
    }

    void Like()
    {
        anim.SetBool("IsLike", true);
        anim.SetBool("IsHate", false);
    }

    void Hate()
    {
        anim.SetBool("IsHate", true);
        anim.SetBool("IsLike", false);
    }

    void Late()
    {
        anim.SetBool("IsStop", false);
        anim.SetBool("IsHate", true);
        StartCoroutine("LateDestroy");
    }

    private void OnTriggerEnter(Collider coll)
    {
        for (int i = 1; i <= maxDish; i++)
        {
            if (coll.tag == "TARGET"+i)
            {
                chair = i;
                StartCoroutine("OrderStart");
                GameObject.FindGameObjectWithTag("Dish"+i).SendMessage("DwarfStart");
                isStop = true;
                isWalk = false;
            }
        }
    }

    IEnumerator OrderStart()
    {
        yield return new WaitForSeconds(1f);

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
            isStop = false;
            isEat = true;
        }
    }
    
    void OnLove()
    {
        if (!isEnd)
        {
            if (orderCanvas == null)
                print("No Canvas");
            else
                Destroy(orderCanvas.gameObject);

            likeparticle.Play();

            StartCoroutine("DelayLike");

            StartCoroutine("Destroy");

            GameObject.FindGameObjectWithTag("GameController").SendMessage("Love");
        }
    }
    
    void OnHate()
    {
        if (orderCanvas == null)
            print("No Canvas");
        else
            Destroy(orderCanvas.gameObject);

        lefthateparticle.Play();
        righthateparticle.Play();

        StartCoroutine("DelayHate");
        isEnd = true;

        StartCoroutine("Destroy");
        GameObject.FindGameObjectWithTag("GameController").SendMessage("Hate");
    }

    void OnPoison()
    {
        if (orderCanvas == null)
            print("No Canvas");
        else
            Destroy(orderCanvas.gameObject);
        lefthateparticle.Play();
        righthateparticle.Play();
        poPaticle.Play();
        StartCoroutine("DelayHate");
        isEnd = true;

        StartCoroutine("Destroy");

        GameObject.FindGameObjectWithTag("GameController").SendMessage("Hate");
    }

    IEnumerator DelayLike()
    {
        yield return new WaitForSeconds(2f);
        Like();
    }

    IEnumerator DelayHate()
    {
        yield return new WaitForSeconds(2f);
        Hate();
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3f);
        for (int i = 1; i <= 4; i++)
        {
            if(this.gameObject.tag == "DWARF" + i)
            {
                GameObject.FindGameObjectWithTag("TARGET" + i).SendMessage("Play");
            }
        }
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    IEnumerator LateDestroy()
    {
        yield return new WaitForSeconds(1.5f);
        for (int i = 1; i <= 4; i++)
        {
            if (this.gameObject.tag == "DWARF" + i)
            {
                GameObject.FindGameObjectWithTag("TARGET" + i).SendMessage("Play");
            }
        }
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    void IsEnd()
    {
        isEnd = true;
    }

    void End()
    {
        StartCoroutine("TheEnd");
    }
}