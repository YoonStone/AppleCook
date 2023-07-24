using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LikeRankScript : MonoBehaviour {

    public Text LikeRankTxt;
    
    string score;
    
    void Score(int like)
    {
        score = like.ToString();
    }
    
    private void Update()
    {
        LikeRankTxt.text = score;
    }
}

