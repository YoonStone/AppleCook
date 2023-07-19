using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ViveHold_RScipt : MonoBehaviour {

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
    public GameObject recipeCanvas;

    private bool isGripped = false;
    private bool isNoDragging;

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

            if (!isNoDragging) //닿은 물체를 드래그 할 때
            {
                switch (target.tag)
                {
                    case "Next1":
                        recipeCanvas.SendMessage("Next");
                        target.transform.SetParent(null);
                        isGripped = false;
                        target = null; break;
                    case "PLAY":
                        audioS.Play();
                        SceneManager.LoadScene(3);
                        break;
                    default:
                        if (target.GetComponent<Rigidbody>() != null)
                        {
                            target.transform.SetParent(this.transform);
                            target.GetComponent<Rigidbody>().isKinematic = true;
                        }
                        break;
                }
            }
            else //새로운 물체를 생성시켜 드래그 할 때
            {
                switch (target.tag)
                {
                    case "MASSBREAD":
                        target = Instantiate(Resources.Load("bread") as GameObject);
                        target.transform.position = new Vector3(this.transform.position.x - 0.1f, this.transform.position.y - 0.2f, this.transform.position.z + 0.2f);
                        break;
                    case "MASSTARTE":
                        target = Instantiate(Resources.Load("tarte1") as GameObject);
                        target.transform.position = new Vector3(this.transform.position.x - 0.4f, this.transform.position.y - 0.55f, this.transform.position.z + 0.5f);
                        break;
                    case "MASSWAFFLE":
                        target = Instantiate(Resources.Load("waffle1") as GameObject);
                        target.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.3f, this.transform.position.z + 0.7f);
                        break;
                    case "MASSAPPLE":
                        target = Instantiate(Resources.Load("apple") as GameObject);
                        target.transform.position = new Vector3(this.transform.position.x + 0.5f, this.transform.position.y - 0.3f, this.transform.position.z + 0.1f);
                        break;
                    case "JAM":
                        target = Instantiate(Resources.Load("jKnife") as GameObject);
                        target.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.3f, this.transform.position.z + 0.3f);
                        break;
                }
                target.transform.SetParent(this.transform);
                target.GetComponent<Rigidbody>().isKinematic = true;
            }
        }

        //트리거 버튼을 릴리즈 했을 경우
        if (controller.GetHairTriggerUp() && target != null)
        {
            if (target.GetComponent<Rigidbody>() != null)
            {
                var rb = target.GetComponent<Rigidbody>();
                rb.isKinematic = false;
                rb.velocity = controller.velocity * 5;
                rb.angularVelocity = controller.angularVelocity;
            }
            target.transform.SetParent(null);
            isGripped = false;
        }
    }
    
    void OnTriggerEnter(Collider coll)
    {
        if (!isGripped)
        {
            switch (coll.tag)
            {
                case "MASSBREAD":
                case "MASSTARTE":
                case "MASSWAFFLE":
                case "MASSAPPLE":
                case "JAM":
                    target = coll.gameObject;
                    isNoDragging = true;
                    break;
                case "BREAD":
                case "SAND":
                case "SAND1":
                case "SAND2":
                case "POSAND1":
                case "POSAND":
                case "TARTE":
                case "TARTEB":
                case "TARTE1":
                case "TARTE2":
                case "TARTE3":
                case "POTARTE3":
                case "POTARTE":
                case "POJUICE":
                case "JUICE":
                case "JUICE1":
                case "POJUICE1":
                case "WAFFLE":
                case "WAFFLE1":
                case "WAFFLE2":
                case "PLATE":
                case "APPLE":
                case "POAPPLE":
                case "JKNIFE":
                case "PLAY":
                case "Next1":
                case "Next2":
                case "Next3":
                case "Next4":
                    target = coll.gameObject;
                    isNoDragging = false;
                    break;
            }
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (target)
        {
            if (target.gameObject == coll.gameObject)
            {
                target = null;
                isGripped = false;
            }
        }
    }

    //juice1한테서 옴
    void SetTarget(GameObject ob)
    {
        target = ob;
        isNoDragging = false;
        isGripped = true;
        target.transform.SetParent(this.transform);
        target.GetComponent<Rigidbody>().isKinematic = true;
    }

    void SameUp(GameObject ob)
    {
        target = ob;
        target.transform.SetParent(null);
        isGripped = false;
        Destroy(target.gameObject);
        target = null;
    }

    // 사과간 믹서기가 손에서 사라졌을 때
    public void Blender()
    {
        isGripped = false;
        target = null;
    }
}
