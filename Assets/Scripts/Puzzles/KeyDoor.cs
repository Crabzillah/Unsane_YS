
using System;
using UnityEngine;

public class KeyDoor : Interactable
{
    public Animator animator;
    public override void Interact()
    {
        base.Interact();

        CheckForKeys();

        OpenTheDoor();

    }

    private void CheckForKeys()
    {



        Inventory.instance.CheckForKey();
        Debug.Log("Checkin for keys sent from KeyDoor");





    }

    private void OpenTheDoor()
    {

        Debug.Log("We attempt to Open the door if haveKey is TRUE");
        if (Inventory.instance.haveKey == true)
        {
            Debug.Log("Setting Animation Trigger!!!");
            animator.SetTrigger("OpenDoor");


            Inventory.instance.haveKey = false;
            Inventory.instance.RemoveKey();
        }
    }

}
