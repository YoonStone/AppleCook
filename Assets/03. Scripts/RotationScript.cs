using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour {

    Vector3 angle = new Vector3(0, 90, 0);

    void Update () {
        transform.Rotate(angle * Time.deltaTime * 2);
    }
}
