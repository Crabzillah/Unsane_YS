using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
    public Animator animator;
    public GameObject callElevatorText;
    public GameObject needKeyText;
    public GameObject finalShade;
    public AudioSource audioSource;
    public AudioClip openElevator;
    public AudioClip playFinalSound;
    public float textShowTimer;

    bool interactable;
    bool isInRoutine;
    bool elevatorCalled;
    public bool playerHasElevatorKey;

    private void Start()
    {
        elevatorCalled = false;
        isInRoutine = false;
        playerHasElevatorKey = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("MainCamera") && !elevatorCalled)
        {
            Inventory.instance.CheckForElevatorKey();
            callElevatorText.SetActive(true);
            interactable = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            callElevatorText.SetActive(false);
            interactable = false;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            animator.SetTrigger("Open");
            elevatorCalled = true;
            callElevatorText.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("Close");
            
        }
        if (interactable == true)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                if(!Inventory.instance.haveElevatorKey && !isInRoutine)
                {
                    
                    needKeyText.SetActive(true);
                    isInRoutine = true;

                    elevatorCalled = true;
                    callElevatorText.SetActive(false);
                    StartCoroutine(showText());
                }
                else if (Inventory.instance.haveElevatorKey)
                {
                    audioSource.PlayOneShot(openElevator);
                    animator.SetTrigger("Open");
                    elevatorCalled = true;
                    callElevatorText.SetActive(false);
                }
                
            }
        }
    }

    IEnumerator showText()
    {
        yield return new WaitForSeconds(textShowTimer);
        needKeyText.SetActive(false);
        isInRoutine = false;
        elevatorCalled = false;
    }

    public void PlayFinalSound()
    {
        audioSource.PlayOneShot(playFinalSound);
    }

    public void FinalShade()
    {
        finalShade.SetActive(true);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
