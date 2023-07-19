using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndScript : MonoBehaviour
{
    public Image LikeScoreImg;
    public Text LikeScoreTxt, WinTxt;
    public GameObject wood, button;

    string score;
    int love;

    public float EndTime = 180.0f;

    private void Start()
    {
        StartCoroutine("GameEndShow");
    }

    private void Update()
    {
        LikeScoreTxt.text = score;
    }

    void Score(int like)
    {
        love = like;
        score = like.ToString();
    }

    IEnumerator GameEndShow()
    {
        yield return new WaitForSeconds(EndTime);
        wood.SetActive(true);
        EndMessage(); //끝났다고 알려주기

        yield return new WaitForSeconds(0.5f);
        LikeScoreImg.gameObject.SetActive(true);
        LikeScoreTxt.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        if (love > 100)
        {
            WinTxt.text = "난쟁이와 행복하게 살았답니다!";
            WinTxt.gameObject.SetActive(true);
        }
        else if (love <= 100)
        {
            WinTxt.text = "백설공주는 쫓겨나고 말았어요..";
            WinTxt.gameObject.SetActive(true);
        }
        
        yield return new WaitForSeconds(1.0f);
        button.gameObject.SetActive(true);
    }
    
    //끝났다고 알려주기
    void EndMessage()
    {
        GameObject dwarf, witch;

        for (int i = 1; i < 5; i++)
        {
            dwarf = GameObject.FindGameObjectWithTag("DWARF" + i);
            if (dwarf != null)
            {
                Destroy(dwarf);
            }
        }

        dwarf = GameObject.FindGameObjectWithTag("DWARF");
        witch = GameObject.FindGameObjectWithTag("WITCH");
        if (dwarf != null)
        {
            Destroy(dwarf);
        }
        if(witch != null)
        {
            Destroy(dwarf);
        }

        GameObject.FindGameObjectWithTag("GameController").SendMessage("Stop");
    }
}