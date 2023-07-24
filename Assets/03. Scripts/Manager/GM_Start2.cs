using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//마녀 넣기 1:4
public class GM_Start2 : MonoBehaviour
{
    public Transform createPos;
    public GameObject[] dwarfPrefab, witchPrefab;
    public GameObject gameEnd, rank;

    GameObject dwarf, witch;

    bool isEnd;

    int maxDwarf = 7;
    int like = 0;

    private void Start()
    {
        CreateDwarf();
        rank.SendMessage("Score", like);
        gameEnd.SendMessage("Score", like);
    }


    // 난쟁이를 프리팹에 넣어놓는 작업
    void CreateDwarf()
    {
        if (!isEnd)
        {
            int rand = Random.Range(0, 7);
            
            dwarf = (GameObject)Instantiate(dwarfPrefab[rand]);
            dwarf.SetActive(false);
            StartCoroutine("DwarfDelay", dwarf);
        }
    }

    //난쟁이 딜레이
    IEnumerator DwarfDelay(GameObject dwarf)
    {
        if (!isEnd)
        {
            float num = Random.Range(4f, 6f);
            yield return new WaitForSeconds(num); //난쟁이가 프리팹에 들어오고 5초후에
            
            dwarf.SetActive(true); // 난쟁이 생성

            //1:4의 비율로 마녀:난쟁이
            int rand = Random.Range(0, 5);

            if (rand == 0)
            {
                CreateWitch();
            }
            else
            {
                CreateDwarf();
            }
        }
    }

    // 마녀 프리팹에 넣어놓는 작업
    void CreateWitch()
    {
        if (!isEnd)
        {
            witch = (GameObject)Instantiate(witchPrefab[0]);
            witch.SetActive(false);
            StartCoroutine("WitchDelay", witch);
        }
    }

    //마녀 딜레이
    IEnumerator WitchDelay(GameObject witch)
    {
        if (!isEnd)
        {
            float num = Random.Range(4f, 6f);
            yield return new WaitForSeconds(num); //난쟁이가 프리팹에 들어오고 5초후에

            witch.SetActive(true); // 난쟁이 생성
            CreateDwarf();
        }
    }

    //좋아할 때
    void Love()
    {
        like += 15;
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