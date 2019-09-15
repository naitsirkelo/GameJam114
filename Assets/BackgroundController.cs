using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class BackgroundController : MonoBehaviour {

    public float speed = 5f;

    GroundController groundController;
    GoldMaker goldController;

    bool day = true;
    bool switched = false;

    void Start() {

        groundController = FindObjectOfType<GroundController>();
        goldController = FindObjectOfType<GoldMaker>();

    }

    void Update() {

        transform.Rotate(0, 0, speed * Time.deltaTime);

        float z = gameObject.transform.rotation.eulerAngles.z;

        Debug.Log(z);

        if (z > 270f && z < 360f || z < 90f && z > 0f) {

            day = true;

        } else if (z > 90f && z < 270f) {

            day = false;

        }

        if (day) {

            Debug.Log("DAY");
            if (!switched) {

                switched = true;
                groundController.Day();
                goldController.Day();
            }

        } else {

            Debug.Log("NIGHT");
            if (switched) {

                switched = false;
                groundController.Night();
                goldController.Night();

            }
        }
    }
}
