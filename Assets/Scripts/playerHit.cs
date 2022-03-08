using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHit : MonoBehaviour
{
    public GameObject playerRagdoll;
    public GameObject player;
    public GameObject playerTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            playerRagdoll.SetActive(true);
            player.SetActive(false);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "boom")
        {
            playerRagdoll.SetActive(true);
            playerTarget.transform.parent = GameObject.FindGameObjectWithTag("PlayerHead").transform;
            player.SetActive(false);
            Destroy(collision.gameObject);

            //playerTarget.transform.localPosition = new Vector3(0.037f, 1.43f, 0.07f);
        }
    }
}
