using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    static AudioSource audioSource;

    void Start() {

        audioSource = gameObject.GetComponent<AudioSource>();

    }

    void Update() {

    }

    public static void PlaySound(string s) {

        switch(s) {
            case "goldPickup":
                audioSource.Play();
                break;
            default:
                break;

        }

    }
}
