using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillEvent : MonoBehaviour
{
    public GameObject pill;
    public GameObject pillInHand;
    public GameObject bedEvent;
    
    public GameObject fakeText;
    public GameObject consumeText;

    private void Start()
    {
        fakeText.SetActive(true);
        consumeText.SetActive(true);
    }
    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.F))
        {
            SpawnPill();
            pillInHand.SetActive(false);
            fakeText.SetActive(false);
            consumeText.SetActive(false);


            // start bed event
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            pillInHand.SetActive(false);
            bedEvent.SetActive(true);
            fakeText.SetActive(false);
            consumeText.SetActive(false);
        }
    }

    private void SpawnPill()
    {
        Instantiate(pill, transform.position, transform.rotation);
    }
}
