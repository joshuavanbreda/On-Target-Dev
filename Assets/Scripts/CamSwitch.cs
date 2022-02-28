using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject playerBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            if (cam1.activeSelf)
            {
                playerBody.transform.parent = null;
                cam1.SetActive(false);
                cam2.SetActive(true);
            }
            else if (cam2.activeSelf)
            {
                playerBody.transform.parent = cam1.transform;
                cam2.SetActive(false);
                cam1.SetActive(true);
            }
        }
    }


}
