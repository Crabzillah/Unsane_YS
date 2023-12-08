using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidingPlace : MonoBehaviour
{
    public GameObject hideText, stopHideText;
    public GameObject normalPlayer, hidingPlayer;
    public enemyAI monsterScript;
    public Transform monsterTransform;
    public Transform exitTransform;
    bool interactable, hiding;
    public float loseDistance;
    public roomDetector detector;

    public AudioSource hideSound, stopHideSound;

    

    void Start()
    {
        interactable = false;
        hiding = false;

        
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (detector.inTrigger == true)
            {
                hideText.SetActive(true); 
                interactable = true;
            }
            else if (detector.inTrigger == false)
            {
                hideText.SetActive(false);
                interactable = false;
            }
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if(detector.inTrigger == true)
            {
                hideText.SetActive(false);
                interactable = false;
            }

        }
    }
    void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {

                hideText.SetActive(false);
                hideSound.Play();
                stopHideSound.Play(); 
                hidingPlayer.SetActive(true);
                float distance = Vector3.Distance(monsterTransform.position, normalPlayer.transform.position);
                if (distance > loseDistance)
                {
                    Debug.Log("Distance is bigger that loseDistance");
                    if (monsterScript.chasing == true)
                    {
                        Debug.Log("Stop to chase");
                        monsterScript.stopChase();
                    }
                }
                stopHideText.SetActive(true);
                hiding = true;
                normalPlayer.SetActive(false);
                normalPlayer.transform.position = exitTransform.position;
                normalPlayer.transform.rotation = exitTransform.rotation;
                interactable = false;
            }
        }
        if (hiding == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                stopHideText.SetActive(false);
                hideSound.Stop();
                stopHideSound.Play();
                normalPlayer.SetActive(true);
                hidingPlayer.SetActive(false);
                hiding = false;
            }
        }
    }
}