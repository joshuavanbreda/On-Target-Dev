using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class SlowMoManager : MonoBehaviour
{
    public MouseLook mouseLook;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            //Time.timeScale = 0.05f;
            //Time.fixedDeltaTime = 0.5f;

            Time.timeScale = 0.05f;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            mouseLook.SensitivityIncrease();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            //Time.timeScale = 0.05f;
            //Time.fixedDeltaTime = 0.5f;

            Time.timeScale = 0.2f;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            mouseLook.SensitivityIncrease();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            //Time.timeScale = 1f;
            //Time.fixedDeltaTime = 1f;

            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;
            mouseLook.SensitivityIncrease();
        }
    }
}
