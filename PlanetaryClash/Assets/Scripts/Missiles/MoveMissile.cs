using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMissile : MonoBehaviour
{
    public GameObject MachineLocation;
    public GameObject NatureLocation;

    float rotSpeed;
    public float speed;


    void Start()
    {
        MachineLocation = GameObject.FindWithTag("MachinePlanet");
        NatureLocation = GameObject.FindWithTag("NaturePlanet");

        

    }

    // Update is called once per frame
    void Update()
    {
      

    }

    private void FixedUpdate()
    {
        if (this.tag == "MachineMissile")
        {
            //  timeSinceStarted += Time.deltaTime;
            // transform.position = Vector3.MoveTowards(transform.position, NatureLocation.transform.position, Time.deltaTime * speed);
            transform.position = Vector3.MoveTowards(transform.position, NatureLocation.transform.position, speed * Time.deltaTime);
        }

        if (this.tag == "NatureMissile")
        {

            //transform.position = Vector3.SmoothDamp(transform.position, MachineLocation.transform.position, ref velocity, speed);

            //transform.position = Vector3.MoveTowards(transform.position, MachineLocation.transform.position, Time.deltaTime * speed);
            transform.position = Vector3.MoveTowards(transform.position, MachineLocation.transform.position, speed * Time.deltaTime);
        }
    }
}
