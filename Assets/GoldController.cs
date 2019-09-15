using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldController : MonoBehaviour {

    static AudioSource audioSource;

    public ParticleSystem explosion;

    void Start() {

        audioSource = gameObject.GetComponent<AudioSource>();

    }

    void OnCollisionEnter2D(Collision2D c) {

        if (c.gameObject.CompareTag("Player")) {

            audioSource.Play();
            Explode(gameObject.transform.position);
            StartCoroutine(Remove());

        }

    }

    public void Explode(Vector3 position) {

       Instantiate(explosion, position, Quaternion.identity);

    }

    IEnumerator Remove() {

        yield return new WaitForSeconds(0.6f);

        Destroy(this.gameObject);

    }

}
