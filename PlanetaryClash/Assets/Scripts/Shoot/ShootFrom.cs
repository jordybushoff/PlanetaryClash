using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFrom : MonoBehaviour
{
    public GameObject[] asteroids;

    public GameObject[] spawnPositions;

    public float spawnRate;
    private float NextSpawn;

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
        NextSpawn=spawnRate;
        Vector2 position = spawnPositions[Random.Range(0, spawnPositions.Length)].transform.position;
        GameObject asteroidClone = Instantiate(asteroids[Random.Range(0, asteroids.Length)], new Vector2(position.x, position.y), transform.rotation);
        asteroidClone.SetActive(true);
    }
}
