using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour
{
    public CameraFollowTarget cameraFollowTarget;
    public GameObject ArrowPrefab;
    public Transform ArrowLaunch;
    public float ArrowSpeed;
    public float FireRate;
    private float firetimer;

    private bool arrowCamCheck = false;
    public GameObject arrowCamera;
    public GameObject mainCam;
    public GameObject cam2;
    public GameObject playerObj;
    public GameObject endTargetFail;

    public GameObject permArrow;

    public GameObject crosshair;

    public GameObject playerController;


    private Camera cam;
    private Animator anim;
    void Start()
    {
        cam = GetComponentInParent<Camera>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        bool pressedK = false;

        if (Input.GetKeyDown(KeyCode.K))
        {
            pressedK = !pressedK;
        }

        if (pressedK == true)
        {
            cameraFollowTarget.target = endTargetFail.transform; //playerObj (before endTargetFail)
            cameraFollowTarget.transform.rotation = Quaternion.identity;

            playerObj.transform.parent = playerController.transform;
        }


        firetimer -= Time.deltaTime;                                                                 //minus 1 per second

        if(Input.GetButtonDown("Fire1") && firetimer <=0f)                                            //if left click and fire timer less than zero
        {
            Vector3 middleofScreen = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 100f));          //Find the middle of the screen with z offset of 100f (fakes shooting to the middle)
            ArrowLaunch.LookAt(middleofScreen);                                                       //makes the launchtransform look at it

            GameObject arrow = Instantiate(ArrowPrefab, ArrowLaunch.position, ArrowLaunch.rotation); //Instantiate the arrow
            arrow.GetComponent<Rigidbody>().velocity = (arrow.transform.forward * ArrowSpeed);        //Set the velocity of the arrow
            firetimer = FireRate;                                                                  // Makes the firetimer go back to the default firerate;


            cameraFollowTarget.target = arrow.transform;

            if (arrowCamCheck == true)
            {
                crosshair.SetActive(false);
                arrowCamera.SetActive(true);
                mainCam.SetActive(false);
                cam2.SetActive(false);
                //arrowCamera.transform.parent = arrow.transform;
                playerObj.transform.parent = null;
            }
            else if (arrowCamCheck == false)
            {
                arrowCamera.SetActive(false);
                mainCam.SetActive(true);
                cam2.SetActive(false);
                //arrowCamera.transform.parent = null;
                playerObj.transform.parent = mainCam.transform;
            }

            anim.SetBool("shoot", true);
            StartCoroutine(ShootAnimationWait());
            //anim.Play("Shoot");                                                                      //Play Shoot Animation

        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            if (arrowCamCheck == true)
            {
                arrowCamCheck = false;
                print("arrowCam is Off");
            }
            else if(arrowCamCheck == false)
            {
                arrowCamCheck = true;
                print("arrowCam is On");
            }
        }
    }

    public IEnumerator ShootAnimationWait()
    {
        permArrow.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("shoot", false);
        yield return new WaitForSeconds(0.5f);
        permArrow.SetActive(true);
    }
}
