using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    private Rigidbody[] _rigidbodies;
    private Rigidbody[] rigidbodies
    {
        get
        {
            if (_rigidbodies == null)
                _rigidbodies = GetComponentsInChildren<Rigidbody>();
            return _rigidbodies;
        }
    }
    // Start is called before the first frame update
    private void Awake()
    {
        DisableRagdoll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collision)
    {
        print("hit Something");
        if (collision.tag == "boom")
        {
            collision.attachedRigidbody.velocity = Vector3.zero;
            collision.attachedRigidbody.angularVelocity = Vector3.zero;

            GetComponent<Animator>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            EnableRagdoll();
            print("hit Arrow!");
        }
    }
    private void DisableRagdoll()
    {
        foreach (var rb in rigidbodies)
        {
            rb.isKinematic = true;
        }
    }

    public void EnableRagdoll()
    {
        foreach (var rb in rigidbodies)
        {
            rb.isKinematic = false;
        }
    }
}
