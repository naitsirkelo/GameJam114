using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldMaker : MonoBehaviour {

    public float maxX = 7.4f;
    public float minX = -7.9f;
    public float minY = 3.5f;

    public float delay = 0.5f;
    public float spawnTime = 1.5f;
    public float spawnTimeBill = 0.15f;

    bool day = true;

    public GameObject gold;
    public GameObject bill;

    void Start() {

        InvokeRepeating("SpawnGold", delay, spawnTime);
        InvokeRepeating("SpawnBills", delay, spawnTimeBill);

    }

    void SpawnGold() {

        float x = Random.Range(minX, maxX);

        if (day) {

            Instantiate(gold, new Vector3(x, minY, 0), Quaternion.identity);

        }

    }

    void SpawnBills() {

        float x = Random.Range(minX, maxX);

        if (!day) {

            Instantiate(bill, new Vector3(x, minY, 0), Quaternion.identity);

        }

    }

    public void Day() {

        day = true;

    }

    public void Night() {

        day = false;

    }
}
