using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour, I_SmartwallInteractable
{
    private Rigidbody rb;
    private Vector3 randomRotation;

    // public float speed;
    private Vector2 direction;

    public int numberOfProjectiles;

    public GameObject asteroidBreakUpSpawn;
    //  public GameObject projectileNature;

    public Transform gravityTarget;
    public Transform gravityTarget2;

    Vector3 startpointBreakup;

    public float speed;

    float radius, moveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        randomRotation = new Vector3(Random.Range(0f, 100f), Random.Range(0f, 100f), Random.Range(0f, 100f));

        radius = 5f;
        moveSpeed = 100f;


    }

    void Update()
    {
    
    }

    void FixedUpdate()
    {
        transform.Rotate(randomRotation * Time.deltaTime);

    }

    void SpawnProjectiles(int numberOfProjectiles)
    {
        float angleStep = 360f / numberOfProjectiles;
        float angle = 0f;

        for (int i = 0; i <= numberOfProjectiles - 1; i++)
        {
            startpointBreakup = this.transform.position;

            float projectileDirXpositionBreakup = startpointBreakup.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYpositionBreakup = startpointBreakup.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;


            Vector3 projectileVectorMachine = new Vector3(projectileDirXpositionBreakup, projectileDirYpositionBreakup);
            

            Vector3 projectileMoveDirectionMachine = (projectileVectorMachine - startpointBreakup).normalized * moveSpeed;



            GameObject AsteroidKogel = Instantiate(asteroidBreakUpSpawn, startpointBreakup, Quaternion.identity);

            AsteroidKogel.GetComponent<SlowlyToMid>().RechtsOm = true;

            AsteroidKogel.GetComponent<SlowlyToMid>().gravityTarget = gravityTarget;
            AsteroidKogel.GetComponent<SlowlyToMid>().gravityTarget2 = gravityTarget2;


            AsteroidKogel.GetComponent<Rigidbody>().velocity = new Vector3(projectileMoveDirectionMachine.x, projectileMoveDirectionMachine.y);
            

            angle += angleStep;
            Destroy(gameObject);
        }
    }

    public void Hit(Vector3 hitPosition)
    {
        SpawnProjectiles(numberOfProjectiles);


    }
}