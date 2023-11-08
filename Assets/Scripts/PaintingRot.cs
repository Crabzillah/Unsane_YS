using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingRot : Interactable
{
    public Animator m_Animator;
    public bool isOne;


    public override void Interact()
    {
        base.Interact();

        RotatePainting();
    }

    // Start is called before the first frame update


    // Update is called once per frame


    private void RotatePainting()
    {
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


}
