using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsShootingController : MonoBehaviour
{
   
    public int numberOfProjectiles;

    public GameObject projectileMachine;
    public GameObject projectileNature;

    public Transform startLocationMachine;
    public Transform startLocationNature;

    Vector3 startpointMachine;
    Vector3 startpointNature;

    float radius, moveSpeed;
  
    void Start()
    {
        radius = 5f;
        moveSpeed = 100f;

        startpointMachine = startLocationMachine.position;
        startpointNature = startLocationNature.position;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SpawnProjectiles(numberOfProjectiles);
        }
    }

    void SpawnProjectiles(int numberOfProjectiles)
    {
        float angleStep = 180f / numberOfProjectiles;
        float angle = 0f;

        for (int i = 0; i <= numberOfProjectiles -1; i++)
        {
            float projectileDirXpositionMachine = startpointMachine.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYpositionMacine = startpointMachine.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            float projectileDirXpositionNature = startpointNature.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYpositionNature = startpointNature.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector3 projectileVectorMachine = new Vector3(projectileDirXpositionMachine, projectileDirYpositionMacine);
            Vector3 projectileVectorNature = new Vector3(projectileDirXpositionNature, projectileDirYpositionNature);

            Vector3 projectileMoveDirectionMachine = (projectileVectorMachine - startpointMachine).normalized * moveSpeed;
            Vector3 projectileMoveDirectionNature = (projectileVectorNature - startpointNature).normalized * moveSpeed;

            var projMachine = Instantiate(projectileMachine, startpointMachine, Quaternion.identity);
            var projNature = Instantiate(projectileNature, startpointNature, Quaternion.identity);

            projMachine.GetComponent<Rigidbody>().velocity = new Vector3(projectileMoveDirectionMachine.x, projectileMoveDirectionMachine.y);
            projNature.GetComponent<Rigidbody>().velocity = new Vector3(projectileMoveDirectionNature.x, projectileMoveDirectionNature.y);

            angle += angleStep;
        }
    }
}
