using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFrom : MonoBehaviour
{
    public GameObject[] asteroids;

    public Transform[] spawnPositions;
    public GameObject Location;

    public float spawnRate;
    private float NextSpawn;

    public bool RechtsOm;

    public Transform gravityTarget;
    public Transform gravityTarget2;



    public float speed;

    private void Start()
    {

    }

    private void Update()
    {
        if (NextSpawn > 0)
            NextSpawn -= Time.deltaTime;
        if (NextSpawn<=0)
            Spawn();
    }



    private void Spawn()
    {

        Transform SpawnPlekken = spawnPositions[Random.Range(0, spawnPositions.Length)];
        NextSpawn = spawnRate;
       

        if (SpawnPlekken.gameObject.tag == "RechtsOm")
        {


            GameObject AsteroidKogel = Instantiate(asteroids[Random.Range(0, asteroids.Length)], SpawnPlekken.transform.position, SpawnPlekken.transform.localRotation);
            AsteroidKogel.GetComponent<Rigidbody>().AddForce(AsteroidKogel.transform.forward * speed, ForceMode.Impulse);



            AsteroidKogel.GetComponent<SlowlyToMid>().RechtsOm = true;

            
            AsteroidKogel.GetComponent<SlowlyToMid>().gravityTarget = gravityTarget;
            AsteroidKogel.GetComponent<SlowlyToMid>().gravityTarget2 = gravityTarget2;
        }
        else
        {
            GameObject AsteroidKogel = Instantiate(asteroids[Random.Range(0, asteroids.Length)], SpawnPlekken.transform.position, SpawnPlekken.transform.localRotation);
            AsteroidKogel.GetComponent<Rigidbody>().AddForce(AsteroidKogel.transform.forward * speed, ForceMode.Impulse);



            AsteroidKogel.GetComponent<SlowlyToMid>().RechtsOm = false;

            
            AsteroidKogel.GetComponent<SlowlyToMid>().gravityTarget = gravityTarget;
            AsteroidKogel.GetComponent<SlowlyToMid>().gravityTarget2 = gravityTarget2;
        }
        


    }
}
