using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMaterials : MonoBehaviour
{

    public GameObject MachineLocation;
    public GameObject NatureLocation;

    float rotSpeed;
    public float speed;

    private MachineHealth MachinePlanetHealth;
    private NatureHealth NaturePlanetHealth;


    // Start is called before the first frame update
    void Start()
    {
        MachineLocation = GameObject.FindWithTag("MachinePlanet");
        NatureLocation = GameObject.FindWithTag("NaturePlanet");

        MachinePlanetHealth = GameObject.FindObjectOfType<MachineHealth>();
        NaturePlanetHealth = GameObject.FindObjectOfType<NatureHealth>();

    }

    private void FixedUpdate()
    {
        var playerScreenPoint = Camera.main.WorldToScreenPoint(this.transform.position);

        if (playerScreenPoint.x < Screen.width / 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, MachineLocation.transform.position, speed * Time.deltaTime);
           // MachineHealth.instance.getStamina(100);
        }
        if (playerScreenPoint.x > Screen.width / 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, NatureLocation.transform.position, speed * Time.deltaTime);
           // NatureHealth.instance.getStamina(100);
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "MachinePlanet")
        {
            if(MachinePlanetHealth.currentHealth < 900 )
            {
                MachineHealth.instance.getStamina(100);
            }
         
            if (MachinePlanetHealth.currentHealth > 900)
            {
                MachinePlanetHealth.currentStamina = MachinePlanetHealth.maxStamina;
            }

            Destroy(this.gameObject);
        }
        
        if (col.gameObject.tag == "NaturePlanet")
        {
            if (NaturePlanetHealth.currentHealth < 900)
            {
                NatureHealth.instance.getStamina(100);
            }

            if (NaturePlanetHealth.currentHealth > 900)
            {
                NaturePlanetHealth.currentStamina = NaturePlanetHealth.maxStamina;
            }

            Destroy(this.gameObject);
        }


    }
}
