using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigAsteroidSpawn : MonoBehaviour
{
    public GameObject[] bigAsteroid;

    public Transform[] spawnPositions;

    public float spawnRate;
    private float NextSpawn;

    public float speed;

    public Transform gravityTarget;
    public Transform gravityTarget2;

    private void Start()
    {
        NextSpawn = 25.0f;
    }

    private void Update()
    {
        if (NextSpawn > 0)
            NextSpawn -= Time.deltaTime;
        if (NextSpawn <= 0)
            Spawn();
    }



    private void Spawn()
    {

        Transform SpawnPlekken = spawnPositions[Random.Range(0, spawnPositions.Length)];
        NextSpawn = spawnRate;


        GameObject AsteroidKogel = Instantiate(bigAsteroid[Random.Range(0, bigAsteroid.Length)], SpawnPlekken.transform.position, SpawnPlekken.transform.localRotation);
        AsteroidKogel.GetComponent<Rigidbody>().AddForce(AsteroidKogel.transform.forward * speed, ForceMode.Impulse);

       // AsteroidKogel.GetComponent<SlowlyToMid>().RechtsOm = true;

        AsteroidKogel.GetComponent<Asteroids>().gravityTarget = gravityTarget;
        AsteroidKogel.GetComponent<Asteroids>().gravityTarget2 = gravityTarget2;


    }
}

