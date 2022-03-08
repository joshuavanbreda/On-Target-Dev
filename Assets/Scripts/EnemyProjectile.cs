using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    public float speed;

    public Transform playerTarget;
    private Vector3 target;



    void Start()
    {
        playerTarget = GameObject.FindGameObjectWithTag("PlayerTarget").transform;

        target = new Vector3(playerTarget.position.x, playerTarget.position.y, playerTarget.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //Rigidbody rb = GetComponent<Rigidbody>();
        //rb.AddForce((player.transform.position - target).normalized * speed);

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        Destroy(gameObject, 0.35f);
    }
}
