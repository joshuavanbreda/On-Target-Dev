using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public EnemyGunMan enemyGunMan;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject playerBody;
    public GameObject crosshair;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            playerBody.transform.parent = null;
            cam1.SetActive(false);
            cam2.SetActive(true);

            crosshair.SetActive(false);
            anim.SetBool("cam2Move", true);

        }
    }

    

    //public void ToggleCam()
    //{

    //}
}
