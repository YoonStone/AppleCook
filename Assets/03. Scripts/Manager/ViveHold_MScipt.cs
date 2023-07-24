using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ViveHold_MScipt : MonoBehaviour {

    //SteamVR_TrackedObject를 저장할 변수
    private SteamVR_TrackedObject trackedObj;

    //SteamVR_Controller.Input 클래스의 접근성을 위한 프로퍼티 설정
    private SteamVR_Controller.Device controller
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedObj.index);
        }
    }


    AudioSource audioS;
    private GameObject target;
    private bool isGripped = false;

    void Awake()
    {
        //컨트롤러에 포함된 SteamVR_TrackedObject 스크립트 저장
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        audioS = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (controller == null)
        {
            Debug.Log("Controller is not detected");
            return;
        }

        //트리거 버튼을 클릭 했을 경우
        if (controller.GetHairTriggerDown() && target != null)
        {
            isGripped = true;

            if (target.tag == "PLAY")
            {
                audioS.Play();
                SceneManager.LoadScene(3); //시작
            }
            else
            {
                audioS.Play();
                SceneManager.LoadScene(2); //레시피
            }
        }

        //트리거 버튼을 릴리즈 했을 경우
        if (controller.GetHairTriggerUp() && target != null)
        {
            isGripped = false;
        }
    }
    
    void OnTriggerEnter(Collider coll)
    {

        if (!isGripped)
        {
            if (coll.tag == "PLAY" || coll.tag == "TUTORIAL")
            {
                target = coll.gameObject;
            }
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (target.gameObject == coll.gameObject)
        {
            target = null;
            isGripped = false;
        }
    }
}
