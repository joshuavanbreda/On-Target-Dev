using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiTrigger : MonoBehaviour
{
    public GameObject confetti1;
    public GameObject confetti2;
    public GameObject confetti3;
    public GameObject confetti4;
    public GameObject confetti5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "confTrig")
        {
            StartCoroutine(confettiWait());
        }
    }

    public IEnumerator confettiWait()
    {
        confetti1.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        confetti3.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        confetti5.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        confetti2.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        confetti4.SetActive(true);
    }
}
