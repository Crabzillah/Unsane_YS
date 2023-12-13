using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoor : MonoBehaviour
{
    public Animator animator;
    public enemyAI enemy;
    public GameObject openText;
    public GameObject needKeyText;
    public AudioSource audioSource;
    public AudioClip openSFX;
    public bool doorIsOpen;
    public bool playerHasKey;
    public float textShowTimer;
    bool interactable;
    bool isInRoutine;
    


    private void Start()
    {
        isInRoutine = false;
        doorIsOpen = false;
        playerHasKey = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Inventory.instance.CheckForKey();
            openText.SetActive(true);
            interactable = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            openText.SetActive(false);
            interactable = false;
        }
        if (other.CompareTag("Player") && doorIsOpen && !enemy.chasing)
        {
            Close();
        }
        if (other.CompareTag("MainCamera") && doorIsOpen && !enemy.chasing)
        {
            Close();
        }
        if (other.CompareTag("Enemy") && doorIsOpen && enemy.chasing)
        {
            Close();
        }
    }
    void Update()
    {


        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (doorIsOpen == false)
                {
                    if(!Inventory.instance.haveKey && !isInRoutine)
                    {
                        needKeyText.SetActive(true);
                        isInRoutine = true;
                        openText.SetActive(true);
                        StartCoroutine(showText());
                    }
                    else if (Inventory.instance.haveKey)
                    {
                        audioSource.PlayOneShot(openSFX);
                        Open();
                        openText.SetActive(false);
                    }
                    
                }
            }
        }
    }

    void SetDoorClosed()
    {
        doorIsOpen = false;
    }

    void Close()
    {

        animator.ResetTrigger("Open");
        animator.SetTrigger("Close");
    }
    void Open()
    {

        animator.ResetTrigger("Close");
        animator.SetTrigger("Open");
        doorIsOpen = true;
    }

    IEnumerator showText()
    {
        yield return new WaitForSeconds(textShowTimer);
        needKeyText.SetActive(false);
        isInRoutine = false;
    }

}
