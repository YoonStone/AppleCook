using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//만들어야 할 음식 종류 결정, 판단 
public class RecipeScript : MonoBehaviour {

    AudioSource audioS;
    public GameObject dish2, next, o;
    public Image recipe1, recipe2, recipe3, recipe4;

    enum CanvasState
    {
        waffle,
        sand,
        tarte,
        juice
    }

    CanvasState cState;

    private void Start()
    {
        cState = CanvasState.waffle;
        audioS = GetComponent<AudioSource>();
        dish2.gameObject.SendMessage("Send", "WAFFLE");
    }

    public void Next()
    {
        audioS.Play();
        next.gameObject.SetActive(false);
        o.gameObject.SetActive(false);
        switch (cState)
        {
            case CanvasState.waffle:
                recipe1.gameObject.SetActive(false);
                recipe2.gameObject.SetActive(true);
                dish2.gameObject.SendMessage("Send", "SAND");
                cState = CanvasState.sand;
                break;
            case CanvasState.sand:
                recipe2.gameObject.SetActive(false);
                recipe3.gameObject.SetActive(true);
                dish2.gameObject.SendMessage("Send", "TARTE");
                cState = CanvasState.tarte;
                break;
            case CanvasState.tarte:
                recipe3.gameObject.SetActive(false);
                recipe4.gameObject.SetActive(true);
                dish2.gameObject.SendMessage("Send", "JUICE");
                cState = CanvasState.juice;
                break;

        }
    }
}
