using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorInteract : MonoBehaviour
{
    public Animator animator;
    public enemyAI enemy;
    public GameObject openText;
    public bool doorIsOpen;
    bool interactable;
    //public float doorCloseTimer;
    // Start is called before the first frame update
    private void Start()
    {
        doorIsOpen = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Enemy") && enemy.chasing)
        //{
        //    animator.ResetTrigger("Close");
        //    animator.SetTrigger("FastOpen");
        //    doorIsOpen = true;
            
        //}
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
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
        if(other.CompareTag("Enemy") && doorIsOpen && enemy.chasing)
        {
            Close();
        }
    }
    void Update()
    {
        //if (doorIsOpen == true)
        //{
        //    Debug.Log("DOOROPEN IS TRUE! - TRY COROUTINE");
        //    StartCoroutine(CloseDoor());
        //}
       
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (doorIsOpen == false)
                {
                    Open();
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

    //IEnumerator CloseDoor()
    //{
    //    animator.ResetTrigger("OpenDoor");

    //    Debug.Log("START TO COUNT FAIT FOR SECONDS");
    //    yield return new WaitForSeconds(doorCloseTimer);
        
    //    animator.SetTrigger("DoorClose");
    //    doorIsOpen = false;
        
    //}
     
}
