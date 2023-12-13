using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorInteract : MonoBehaviour
{
    public Animator animator;
    public enemyAI enemy;
    public GameObject openText;
    public AudioSource audioSource;
    public AudioClip openSFX;
    public AudioClip closeSFX;
    
    public bool doorIsOpen;
    bool interactable;
    
    
    private void Start()
    {
        doorIsOpen = false;
    }
    
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera") && !enemy.isInDeathRoutine)
        {
            openText.SetActive(true);
            interactable = true;
        }
        else
        {
            openText.SetActive(false);
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
        if(other.CompareTag("Enemy") && doorIsOpen && enemy.chasing)
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
                    Open();
                    
                    audioSource.PlayOneShot(openSFX);
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
    
    public void PlayCloseSound()
    {
        AudioSource closeAudioSource = GetComponentInChildren<AudioSource>();
        closeAudioSource.PlayOneShot(closeSFX);
        //audioSource.PlayOneShot(closeSFX);
    }

    
     
}
