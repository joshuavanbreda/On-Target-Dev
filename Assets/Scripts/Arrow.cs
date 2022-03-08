using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (rb != null)
        {
            if (rb.velocity.magnitude >= 0.2f)
                transform.rotation = Quaternion.LookRotation(-rb.velocity); //Make arrow rotation follow velocity(so it looks more like an arrow and curves upwards/downwards)
        }
        
    }
    private void OnCollisionEnter(Collision col)
    {
        transform.parent = col.transform;
        Rigidbody rb = transform.GetComponent<Rigidbody>(); // transform.root
        //rb.velocity = new Vector3(0,0,0);
        rb.isKinematic = true;
        rb.useGravity = false;

        //Destroy(gameObject,0.05f);
        Destroy(rb);
    }
}
