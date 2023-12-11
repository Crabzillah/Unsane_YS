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

    private void OnEnable()
    {
        pillInHand.SetActive(true);
        fakeText.SetActive(true);
        consumeText.SetActive(true);
        
    }
    
    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.F))
        {
            SpawnPill();
            pillInHand.SetActive(false);
            bedEvent.SetActive(true);
            fakeText.SetActive(false);
            consumeText.SetActive(false);
            this.gameObject.SetActive(false);


            // start bed event
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            pillInHand.SetActive(false);
            bedEvent.SetActive(true);
            fakeText.SetActive(false);
            consumeText.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

    private void SpawnPill()
    {
        Instantiate(pill, pillInHand.transform.position, pillInHand.transform.rotation);
    }
}
