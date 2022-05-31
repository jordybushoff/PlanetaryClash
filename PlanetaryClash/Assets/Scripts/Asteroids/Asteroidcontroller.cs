using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroidcontroller : MonoBehaviour, I_SmartwallInteractable
{

    private Rigidbody rb;
    private Vector3 randomRotation;
    //private float removePositionZ;

    public ParticleSystem DestructionEffect;

    public GameObject materialAsteroid;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        randomRotation = new Vector3(Random.Range(0f, 30f), Random.Range(0f, 30f), Random.Range(0f, 30f));

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(randomRotation * Time.deltaTime);
        
    }

    public void DestroyAsteroid()
    {
        Destroy(gameObject);
    }



    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "MachinePlanet")
        {
            var healthComponent = col.GetComponent<MachineHealth>();
            if(healthComponent != null)
            {
                healthComponent.TakeDamage(10);
            }
          
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "NaturePlanet")
        {

            var healthComponent = col.GetComponent<NatureHealth>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(10);
            }

            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "ShieldRed")
        {
            ParticleSystem explosionEffect = Instantiate(DestructionEffect, transform.position, Quaternion.identity) as ParticleSystem;
            Destroy(gameObject);
            MachineHealth.instance.UseStamina(20);
        }

        if (col.gameObject.tag == "ShieldBlue")
        {
            ParticleSystem explosionEffect = Instantiate(DestructionEffect, transform.position, Quaternion.identity) as ParticleSystem;
            Destroy(gameObject);
            NatureHealth.instance.UseStamina(20);
        }

    }
    
  
    
    public void Hit(Vector3 hitPosition)
    {
        ParticleSystem explosionEffect = Instantiate(DestructionEffect, transform.position, Quaternion.identity) as ParticleSystem;

        GameObject AsteroidKogel = Instantiate(materialAsteroid, this.transform.position, this.transform.localRotation);
        /*
        var playerScreenPoint = Camera.main.WorldToScreenPoint(this.transform.position);

        if (playerScreenPoint.x < Screen.width/2)
        {
            MachineHealth.instance.getStamina(100);
        }
        if (playerScreenPoint.x > Screen.width/2)
        {
            NatureHealth.instance.getStamina(100);
        }
        */

        Destroy(gameObject);

    }
}
