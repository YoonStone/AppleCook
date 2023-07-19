using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLimitScript : MonoBehaviour{
    public ParticleSystem lefthateparticle, righthateparticle;
    public Canvas orderCanvas;

    public Image timeLimit;
    public float waitTime = 30.0f;

    private void Start()
    {
        StartCoroutine("OnAngry");
    }

    void Update()
    {
        timeLimit.fillAmount += 1.0f / waitTime * Time.deltaTime;
    }

    IEnumerator OnAngry()
    {
        yield return new WaitForSeconds(waitTime);

        if (orderCanvas == null)
            print("No Canvas");
        else
            Destroy(orderCanvas.gameObject);

        lefthateparticle.Play();
        righthateparticle.Play();

        lefthateparticle.transform.parent.gameObject.SendMessage("IsEnd");
        lefthateparticle.transform.parent.gameObject.SendMessage("Late");
        GameObject.FindGameObjectWithTag("GameController").SendMessage("Hate");
        
    }
}