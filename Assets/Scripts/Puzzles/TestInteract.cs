
using System;
using UnityEngine;

public class TestInteract : Interactable
{
    public Animator m_Animator;
    public bool isOne;
    public float myCurrentNumber;

    public bool isPaintingA;
    public bool isPaintingB;
    public bool isPaintingC;
    public bool isPaintingD;

    public override void Interact()
    {
        base.Interact();

        StartInteract();
    }

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
            Door.instance.paintingAindex = 1f;
        }
        else if (isPaintingB)
        {
            Door.instance.paintingBindex = 1f;
        }
        else if (isPaintingC)
        {
            Door.instance.paintingCindex = 1f;
        }
        else if (isPaintingD)
        {
            Door.instance.paintingDindex = 1f;
        }
    }

    private void SetToTwo()
    {
        if (isPaintingA)
        {
            Door.instance.paintingAindex = 2f;
        }
        else if (isPaintingB)
        {
            Door.instance.paintingBindex = 2f;
        }
        else if (isPaintingC)
        {
            Door.instance.paintingCindex = 2f;
        }
        else if (isPaintingD)
        {
            Door.instance.paintingDindex = 2f;
        }
    }
}
