using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcMoveScript : MonoBehaviour
{
    private NavMeshAgent navMesh;
    public GameObject[] targetPos = new GameObject[4];
    GameObject dwarf;

    int test;

    void Start()
    { 
        navMesh = GetComponent<NavMeshAgent>();

        //타겟포스 불러오는 부분
        for (int i = 0; i < 4; i++)
        {
            int num = i + 1;
            string tag = "TARGET" + num;
            targetPos[i] = GameObject.FindGameObjectWithTag(tag);
        }
        SetTarget();
    }

    void SetTarget()
    {
        int num = Random.Range(0, 4);
        int test = num + 1;
        dwarf = GameObject.FindGameObjectWithTag("DWARF" + test);
        if (dwarf == null)
        {
            Vector3 target = targetPos[num].transform.position;
            navMesh.SetDestination(target);
            this.gameObject.tag = "DWARF" + test;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
