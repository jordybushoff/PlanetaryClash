using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutmaticSchootSystem : MonoBehaviour
{
    public Transform[] MachineMissilesSpawns;
    public Transform[] NatureMissilesSpawns;

    public GameObject[] MachineMissiles;
    public GameObject[] NatureMissiles;

    public enum SpawnState { SPAWNING, WAITING, COUNTING};
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public Transform enemy2;
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

        if (nextWave + 1 > waves.Length -1)
        {
            nextWave = 0;
            Debug.Log("ALL waves complete! Loopoing...");
        }
        else
        {
            nextWave++;
        }
        
    }

    bool EnemyIsAlive ()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;

            if (GameObject.FindGameObjectsWithTag("MachineMissile").Length == 0 && GameObject.FindGameObjectsWithTag("NatureMissile").Length == 0)
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
            SpawnEnemy(_wave.enemy, _wave.enemy2);
           

            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

      
    void SpawnEnemy(Transform _enemy, Transform _enemy2)
    {

        Debug.Log("Spawning Enemy  :" + _enemy.name);

        

        Transform _spMachine = MachineMissilesSpawns[Random.Range(0, MachineMissilesSpawns.Length)];
        Transform _spNature = NatureMissilesSpawns[Random.Range(0, NatureMissilesSpawns.Length)];

        GameObject Enemy = Instantiate(_enemy.gameObject, _spMachine.position, _spMachine.rotation);
        GameObject Enemy2 = Instantiate(_enemy2.gameObject, _spNature.position, _spNature.rotation);

      
        Enemy.GetComponent<Rigidbody>().AddForce(Enemy.transform.forward * spawnSpeed, ForceMode.Impulse);

       
        Enemy2.GetComponent<Rigidbody>().AddForce(Enemy2.transform.forward * spawnSpeed, ForceMode.Impulse);

        //Instantiate(_enemy, _spMachine.position, _spMachine.rotation);
        
       
       // Instantiate(_enemy2, _spNature.position, _spNature.rotation);
    }

    
}
