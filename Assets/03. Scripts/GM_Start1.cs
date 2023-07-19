using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//마녀 넣기 1:4
public class GM_Start1 : MonoBehaviour
{
    public Transform createPos;
    public GameObject[] dwarfPrefab;
    public GameObject gameEnd, rank;
    GameObject[] dwarfPool;
    GameObject dwarf1,dwarf2, dwarf3, dwarf4;

    int chairNum;
    int randomNum;

    bool isEnd;
    bool isFirst;

    int maxDwarf = 7;
    int like = 0;

    private void Start()
    {
        dwarfPool = new GameObject[maxDwarf];
        isFirst = true;
        CreateDwarf();
        rank.SendMessage("Score", like);
        gameEnd.SendMessage("Score", like);
    }


    // 난쟁이를 프리팹에 넣어놓는 작업
    void CreateDwarf()
    {
        if (!isEnd)
        {
            for (int i = 0; i < maxDwarf; i++)
            {
                dwarfPool[i] = (GameObject)Instantiate(dwarfPrefab[i]);
                dwarfPool[i].SetActive(false);
            }
            StartCoroutine("DwarfDelay");
        }
    }

    //난쟁이 딜레이
    IEnumerator DwarfDelay()
    {
        if (!isEnd)
        {
            float num = Random.Range(4f, 6f);
            yield return new WaitForSeconds(num); //난쟁이가 프리팹에 들어오고 3초후에

            int rand = Random.Range(0, 7);
            dwarfPool[rand].transform.position = createPos.position;
            dwarfPool[rand].SetActive(true); // 난쟁이 생성
            CreateDwarf();
        }
    }

    //좋아할 때
    void Love()
    {
        like += 10;
        gameEnd.SendMessage("Score", like);
        rank.SendMessage("Score", like);
    }

    //싫어할 때
    void Hate()
    {
        if (like > 0)
        {
            like -= 10;
            gameEnd.SendMessage("Score", like);
            rank.SendMessage("Score", like);
        }
    }

    //게임 끝 - GameScript에서 옴
    void Stop()
    {
        isEnd = true;
    }
}