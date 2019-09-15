using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillController : MonoBehaviour {

    static AudioSource audioSource;

    public float lifetime = 2f;

    void Start() {

        audioSource = gameObject.GetComponent<AudioSource>();
        Destroy(gameObject, lifetime);

    }

    void OnCollisionEnter2D(Collision2D c) {

        if (c.gameObject.CompareTag("Player")) {

            audioSource.Play();
            StartCoroutine(Remove());

        }

    }

    IEnumerator Remove() {

        yield return new WaitForSeconds(0.6f);

        Destroy(this.gameObject);

    }

}
