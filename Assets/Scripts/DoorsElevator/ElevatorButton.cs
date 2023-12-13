using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : MonoBehaviour
{
    public Animator animator;
    public GameObject useText;
    public AudioSource audioSource;
    public AudioClip closeElevator;

    bool interactable;
    bool buttonPushed;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera") && !buttonPushed)
        {
            useText.SetActive(true);
            interactable = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            useText.SetActive(false);
            interactable = false;
        }
    }
    private void Update()
    {
        if (interactable == true)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                audioSource.PlayOneShot(closeElevator);
                animator.SetTrigger("Close");
                useText.SetActive(false);
                buttonPushed = true;

            }
        }
    }

}
