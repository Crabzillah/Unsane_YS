using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Animator animator;
    public GameObject callElevatorText;
    public GameObject needKeyText;
    public float textShowTimer;

    bool interactable;
    bool isInRoutine;
    public bool playerHasElevatorKey;

    private void Start()
    {
        isInRoutine = false;
        playerHasElevatorKey = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            Inventory.instance.CheckForKey();
            callElevatorText.SetActive(true);
            interactable = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            callElevatorText.SetActive(true);
            interactable = false;
        }
    }

    private void Update()
    {
        while(interactable == true)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                if(!Inventory.instance.haveKey && !isInRoutine)
                {
                    needKeyText.SetActive(true);
                    isInRoutine = true;
                    StartCoroutine(showText());
                }
                else if (Inventory.instance.haveKey)
                {
                    animator.SetTrigger("Open");
                }
                else
                {
                    return;
                }
            }
        }
    }

    IEnumerator showText()
    {
        yield return new WaitForSeconds(textShowTimer);
        needKeyText.SetActive(false);
        isInRoutine = false;
    }

}
