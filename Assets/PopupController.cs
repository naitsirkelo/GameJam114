using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour {

    public float disappearTime = 1f;

    private Color textColor;

    void Update() {

        disappearTime -= Time.deltaTime;

        if (disappearTime < 0) {

            Destroy(this.gameObject);

        }
    }
}
