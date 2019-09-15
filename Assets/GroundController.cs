using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour {

    public SpriteRenderer ground;

    Color dayColor;
    Color nightColor;

    void Start() {

        ground = GetComponent<SpriteRenderer>();

        nightColor = new Color(15f/255f, 153f/255f, 51f/255f);
        dayColor = new Color(153f/255f, 255f/255f, 153f/255f);

    }

    public void Day() {

        Debug.Log("Day");
        ground.color = dayColor;

    }

    public void Night() {

        Debug.Log("Night");
        ground.color = nightColor;

    }
}
