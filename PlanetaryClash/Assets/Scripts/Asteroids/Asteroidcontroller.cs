using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroidcontroller : MonoBehaviour
{

    private Rigidbody rb;
    private Vector3 randomRotation;
    //private float removePositionZ;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        randomRotation = new Vector3(Random.Range(0f, 100f), Random.Range(0f, 100f), Random.Range(0f, 100f));

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(randomRotation * Time.deltaTime);
    }

    public void DestroyAsteroid()
    {
        Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "MachinePlanet" || col.gameObject.tag == "NaturePlanet")
        {
            Debug.Log("collision detected!");
            Destroy(this.gameObject);
        }
    }
}
