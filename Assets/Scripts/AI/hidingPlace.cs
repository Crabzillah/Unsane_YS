using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidingPlace : MonoBehaviour
{
    public GameObject hideText, stopHideText;
    public GameObject normalPlayer, hidingPlayer;
    public enemyAI monsterScript;
    public Transform monsterTransform;

    bool interactable, hiding;

    public float loseDistance;


    private void Start()
    {
        interactable = false;
        hiding = false; 
    }



    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            hideText.SetActive(true);
            interactable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        {
            if (other.CompareTag("MainCamera"))
            {
                hideText.SetActive(false); ;
                interactable = true;
            }
        }
    }

    private void Update()
    {
        if (interactable == true)
        {
            if(Input.GetKey(KeyCode.F))
            {
                hideText.SetActive(false);
                hidingPlayer.SetActive(true);

                float distance = Vector3.Distance(monsterTransform.position, normalPlayer.transform.position);
                if(distance > loseDistance)
                {
                    if(monsterScript.chasing == true)
                    {
                        monsterScript.stopChase(); //ep02, 4:27 11.11.23
                    }
                }
            }
        }
    }
}
