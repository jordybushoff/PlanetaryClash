using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowlyToMid : MonoBehaviour
{
    public float timeCounter = 0;

    public float radiansCircle = 360 / Mathf.Rad2Deg;

    public float crashSpeed;

    public float speed;
    
    public Transform gravityTarget;
    public Transform gravityTarget2;

    bool gravityAan = false;
    bool gravityAan2 = false;

    public float orbalDistance;

    public bool RechtsOm = false;
    

    public float gravity = 9.81f;
    Rigidbody rb;

    public int maxRange;
    public int minRange;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 0.25f;
       
    }

    void FixedUpdate()
    {
        ProcessGravity();
    }


    void ProcessGravity()
    {
        if (gravityAan == true)
        {
            if(RechtsOm)
            {
                timeCounter -= Time.deltaTime * speed;
            }
            else
            {
                timeCounter += Time.deltaTime * speed;
            }

            orbalDistance -= Time.deltaTime * crashSpeed;

            float x = Mathf.Cos(timeCounter)*orbalDistance + gravityTarget.position.x;
            float y = Mathf.Sin(timeCounter)*orbalDistance + gravityTarget.position.y;
            float z = gravityTarget.position.z;

            transform.position = new Vector3(x, y, z);
        }

        if (gravityAan2 == true)
        {
            if (RechtsOm)
            {
                timeCounter -= Time.deltaTime * speed;
            }
            else
            {
                timeCounter += Time.deltaTime * speed;
            }

            orbalDistance -= Time.deltaTime * crashSpeed;

            float x = Mathf.Cos(timeCounter)* orbalDistance + gravityTarget2.position.x;
            float y = Mathf.Sin(timeCounter)* orbalDistance + gravityTarget2.position.y;
            float z = gravityTarget2.position.z;

            transform.position = new Vector3(x, y, z);
        }


        if (Vector3.Distance(gravityTarget.position, this.transform.position) < minRange)
        {
            if (!gravityAan)
            {
                gravityAan = true;
                float temp = Mathf.Acos((transform.position.x - gravityTarget.position.x) / orbalDistance);
                if (transform.position.y < gravityTarget.position.y)
                {
                    timeCounter = (radiansCircle - temp);
                }
                else
                {
                    timeCounter = (temp);
                }
            }
        }

        if (Vector3.Distance(gravityTarget2.position, this.transform.position) < minRange)
        {
            if (!gravityAan2)
            {
                gravityAan2 = true;
                float temp = Mathf.Acos((transform.position.x - gravityTarget2.position.x) / orbalDistance);
                if (transform.position.y < gravityTarget2.position.y)
                {
                    timeCounter = (radiansCircle - temp);
                }
                else
                {
                    timeCounter = (temp);
                }
            }
            
        }


    }
}
