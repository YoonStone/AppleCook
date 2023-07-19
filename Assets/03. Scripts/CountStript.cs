using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountStript : MonoBehaviour {

    Text count;
    float time;

    private void Start()
    {
        count = GetComponent<Text>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        float minute = 2 - Mathf.Floor((time % 3600) / 60);
        string minutes = minute.ToString("00");
        float secound = 60 - (time % 60);
        string secounds = secound.ToString("00");

        if(secounds == "60")
        {
            secounds = "59";
        }

        if (minute < 0)
        {
            minutes = "00";
            secounds = "00";
        }

        count.text = minutes + " : " + secounds;
    }
}
