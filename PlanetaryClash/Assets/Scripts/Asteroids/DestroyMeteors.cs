using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMeteors : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Meteor")
        {
           Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "BigMeteor")
        {

            Destroy(col.gameObject);
        }

       

    }
}
