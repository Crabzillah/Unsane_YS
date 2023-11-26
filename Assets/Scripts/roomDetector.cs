using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomDetector : MonoBehaviour
{
    public bool inTrigger;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = false;
        }
    }

}
