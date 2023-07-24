using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishPos1Script : MonoBehaviour
{
    GameObject dwarf;
    AudioSource audioS;

    int food;
    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    public void DwarfStart()
    {
        dwarf = GameObject.FindGameObjectWithTag("DWARF1");
    }

    void OnTarteStart()
    {
        if (food == 1)
        {
            dwarf.SendMessage("OnLove");
        }
        else if (food == 5)
        {
            dwarf.SendMessage("OnPoison");
        }
        else
        {
            dwarf.SendMessage("OnHate");
        }
    }

    void OnJuiceStart()
    {
        if (food == 2)
        {
            dwarf.SendMessage("OnLove");
        }
        else if (food == 5)
        {
            dwarf.SendMessage("OnPoison");
        }
        else
        {
            dwarf.SendMessage("OnHate");
        }
    }

    void OnSandWichStart()
    {
        if (food == 3)
        {
            dwarf.SendMessage("OnLove");
        }
        else if (food == 5)
        {
            dwarf.SendMessage("OnPoison");
        }
        else
        {
            dwarf.SendMessage("OnHate");
        }
    }

    void OnWaffleStart()
    {
        if (food == 4)
        {
            dwarf.SendMessage("OnLove");
        }
        else if (food == 5)
        {
            dwarf.SendMessage("OnPoison");
        }
        else
        {
            dwarf.SendMessage("OnHate");
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        Destroy(coll.gameObject, 2f);
        switch (coll.gameObject.tag)
        {
            case "TARTE":
                food = 1;
                audioS.Play();
                break;
            case "JUICE":
                food = 2;
                audioS.Play();
                break;
            case "SAND":
                audioS.Play();
                food = 3;
                break;
            case "WAFFLE":
                audioS.Play();
                food = 4;
                break;
            case "POTARTE":
            case "POSAND":
            case "POJUICE":
                coll.gameObject.SendMessage("Poison");
                food = 5;
                audioS.Play();
                break;
            default:
                food = 0;
                break;
        }
        if (dwarf == null)
            print("No Dwarf");
        else
            dwarf.SendMessage("OnTouch");
    }

    private void OnCollisionExit(Collision coll)
    {
        food = 0;
    }
}