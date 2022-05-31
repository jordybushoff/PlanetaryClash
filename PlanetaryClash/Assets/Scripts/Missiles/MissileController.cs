using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour, I_SmartwallInteractable
{
    public ParticleSystem DestructionEffect;
    public ParticleSystem MachineEffect;
    public ParticleSystem NatureEffect;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "MachinePlanet")
        {
            var healthComponent = col.GetComponent<MachineHealth>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(10);
            }

            ParticleSystem explosionEffect = Instantiate(NatureEffect, transform.position, Quaternion.identity) as ParticleSystem;
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "NaturePlanet")
        {

            var healthComponent = col.GetComponent<NatureHealth>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(10);
            }

            ParticleSystem explosionEffect = Instantiate(MachineEffect, transform.position, Quaternion.identity) as ParticleSystem;
            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "ShieldRed")
        {
            ParticleSystem explosionEffect = Instantiate(NatureEffect, transform.position, Quaternion.identity) as ParticleSystem;
            Destroy(gameObject);
            MachineHealth.instance.UseStamina(50);
        }

        if (col.gameObject.tag == "ShieldBlue")
        {
            ParticleSystem explosionEffect = Instantiate(MachineEffect, transform.position, Quaternion.identity) as ParticleSystem;
            Destroy(gameObject);
            NatureHealth.instance.UseStamina(50);
        }

    }

    public void Hit(Vector3 hitPosition)
    {
        if (this.tag == "MachineMissile")
        {
            ParticleSystem explosionEffect = Instantiate(MachineEffect, transform.position, Quaternion.identity) as ParticleSystem;
            Destroy(gameObject);
        }

        if (this.tag == "NatureMissile")
        {
            ParticleSystem explosionEffect = Instantiate(NatureEffect, transform.position, Quaternion.identity) as ParticleSystem;
            Destroy(gameObject);
        }


    }
}
