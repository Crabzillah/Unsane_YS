using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lean : MonoBehaviour
{
    public Animator cameraAnimator;
    public LayerMask layers;
    RaycastHit hit;


    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Q) && !Physics.Raycast(transform.position, -transform.right, out hit, 1f, layers))
        {
            cameraAnimator.ResetTrigger("idle");
            cameraAnimator.ResetTrigger("right");
            cameraAnimator.SetTrigger("left");
        }
        else if (Input.GetKey(KeyCode.E) && !Physics.Raycast(transform.position, transform.right, out hit, 1f, layers))
        {
            cameraAnimator.ResetTrigger("idle");
            cameraAnimator.ResetTrigger("left");
            cameraAnimator.SetTrigger("right");
        }
        else
        {
            cameraAnimator.ResetTrigger("right");
            cameraAnimator.ResetTrigger("left");
            cameraAnimator.SetTrigger("idle");
        }
    }
}
