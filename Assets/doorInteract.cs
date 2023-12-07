using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorInteract : MonoBehaviour
{
    public Animator animator;
    public GameObject openText;
    public bool doorIsOpen = false;
    bool interactable;
    //public float doorCloseTimer;
    // Start is called before the first frame update
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
                    
                    animator.SetTrigger("OpenDoor");
                    doorIsOpen = true;
                }
            }
        }
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
