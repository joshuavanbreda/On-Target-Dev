using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunMan : MonoBehaviour
{
    private float timeBtwShots;
    public float startTimeBtwShots;

    private Transform player;

    public GameObject projectile;
    public GameObject gunPoint;

    public ParticleSystem muzzleFlash;

    public bool startShooting = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(shootWaitEnemy());
        }

        if (startShooting == true)
        {
            if (timeBtwShots <= 0)
            {
                Instantiate(projectile, gunPoint.transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;

                muzzleFlash.Play();
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
        else
        {
            return;
        }
    }

    public IEnumerator shootWaitEnemy()
    {
        yield return new WaitForSeconds(3f);
        startShooting = true;
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "boom")
        {
            transform.GetComponent<EnemyGunMan>().enabled = false;
        }
    }
}
