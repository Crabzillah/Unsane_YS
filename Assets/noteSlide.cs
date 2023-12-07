using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteSlide : MonoBehaviour
{
    public Animator animator;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("slide");
        }
    }
}
