using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorControllerSpawn : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform asteroid;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    public float spawnSpeed;

    public GameObject[] asteroids;

    public Transform[] spawnPositions;
    //public GameObject Location;

    public float spawnRate;
    private float NextSpawn;

    public bool RechtsOm;

    public Transform gravityTarget;
    public Transform gravityTarget2;

    public float speed;

    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }



    // Update is called once per frame
    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }

        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave completed !");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("ALL waves complete! Loopoing...");
        }
        else
        {
            nextWave++;
        }

    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;

            if (GameObject.FindGameObjectsWithTag("Meteor").Length == 0)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.asteroid);


            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }


    void SpawnEnemy(Transform _asteroid)
    {

        Debug.Log("Spawning Enemy  :" + _asteroid.name);

        

        Transform SpawnPlekken = spawnPositions[Random.Range(0, spawnPositions.Length)];
        NextSpawn = spawnRate;


        if (SpawnPlekken.gameObject.tag == "RechtsOm")
        {


            GameObject AsteroidKogel = Instantiate(_asteroid.gameObject, SpawnPlekken.position, SpawnPlekken.rotation);
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
