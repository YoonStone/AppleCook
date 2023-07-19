using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomScript : MonoBehaviour
{
    public Transform blender_pos, cup_pos;

    private void OnCollisionEnter(Collision coll)
    {
        switch (coll.gameObject.tag)
        {
            case "STATIC":
            case "COOKBAR":
                break;
            default:
                StartCoroutine("Respawn", coll);
                break;
        }
    }

    IEnumerator Respawn(Collision coll)
    {
        yield return new WaitForSeconds(1.5f);

        if(coll.gameObject.tag == "BLENDER")
        {
            coll.gameObject.transform.rotation = blender_pos.rotation;
            coll.gameObject.transform.position = blender_pos.position;
        }
        else if(coll.gameObject.tag == "CUP")
        {
            coll.gameObject.transform.rotation = cup_pos.rotation;
            coll.gameObject.transform.position = cup_pos.position;

        }
        else
        {
            Destroy(coll.gameObject);
        }
    }

    // 주스 따르고 나서
    public void RespawnWait()
    {
        StartCoroutine("Respawn2");
    }

    IEnumerator Respawn2()
    {
        yield return new WaitForSeconds(1.5f);

        GameObject blender = Instantiate(Resources.Load("blender") as GameObject);
        blender.transform.rotation = blender_pos.rotation;
        blender.transform.position = blender_pos.position;
    }

}
