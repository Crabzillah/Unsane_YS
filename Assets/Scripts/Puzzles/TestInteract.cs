
using System;
using UnityEngine;

public class TestInteract : MonoBehaviour
{
    public Animator m_Animator;
    public GameObject pushText;
    public bool isOne;
    public float myCurrentNumber;

    public bool isPaintingA;
    public bool isPaintingB;
    public bool isPaintingC;
    public bool isPaintingD;
    public bool isPaintingE;

    bool interactable;
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            pushText.SetActive(true);
            interactable = true;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            pushText.SetActive(false);
            interactable = false;

        }
    }

    private void Update()
    {
        if(interactable == true)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                StartInteract();
            }
        }
    }
    //public override void Interact()
    //{
    //    base.Interact();

    //    StartInteract();
    //}

    private void StartInteract()
    {


        Debug.Log("TEST SUBJECT INTERACTED ");
        if (!isOne)
        {
            m_Animator.ResetTrigger("SetTwo");
            m_Animator.SetTrigger("SetOne");
            isOne = true;
        }
        else
        {
            m_Animator.ResetTrigger("SetOne");
            m_Animator.SetTrigger("SetTwo");
            isOne = false;
        }

    }

    private void SetToOne()
    {
        if (isPaintingA)
        {
            Door.instance.paintingAIndex = 1f;
        }
        else if (isPaintingB)
        {
            Door.instance.paintingBIndex = 5f;
        }
        else if (isPaintingC)
        {
            Door.instance.paintingCIndex = 7f;
        }
        else if (isPaintingD)
        {
            Door.instance.paintingDIndex = 1f;
        }
        else if (isPaintingE)
        {
            Door.instance.paintingEIndex = 2f;
        }
    }

    private void SetToTwo()
    {
        if (isPaintingA)
        {
            Door.instance.paintingAIndex = 0f;
        }
        else if (isPaintingB)
        {
            Door.instance.paintingBIndex = 1f;
        }
        else if (isPaintingC)
        {
            Door.instance.paintingCIndex = 5f;
        }
        else if (isPaintingD)
        {
            Door.instance.paintingDIndex = 2f;
        }
        else if (isPaintingE)
        {
            Door.instance.paintingEIndex = 1f;
        }
    }
}
