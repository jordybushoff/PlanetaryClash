using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorsGravityTo : MonoBehaviour
{
    public Transform gravityTarget;
    public Transform gravityTarget2;

    bool gravityAan = false;
    bool gravityAan2 = false;

    public float gravity = 9.81f;
    Rigidbody rb;

    public int maxRange;
    public int minRange;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        ProcessGravity();
    }


    void ProcessGravity()
    {
        if (gravityAan == true)
        {
            Vector3 diff = transform.position - gravityTarget.position;
            rb.AddForce(-diff.normalized * gravity * (rb.mass));
            Debug.DrawRay(transform.position, diff.normalized, Color.red);
        }

        if (gravityAan2 == true)
        {
            Vector3 diff = transform.position - gravityTarget2.position;
            rb.AddForce(-diff.normalized * gravity * (rb.mass));
            Debug.DrawRay(transform.position, diff.normalized, Color.red);
        }


        if (Vector3.Distance(gravityTarget.position, this.transform.position) < minRange)
        {
           gravityAan = true;
        }

        if (Vector3.Distance(gravityTarget2.position, this.transform.position) < minRange)
        {
            gravityAan2 = true;
        }
        

    }
}
