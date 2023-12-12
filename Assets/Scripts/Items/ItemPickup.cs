
using System;
using UnityEngine;

public class ItemPickup : Interactable
{
    public AudioSource audioSource;
    public AudioClip pickUpSFX;
    public Item item;
    public override void Interact()
    {
        base.Interact();

        PickUp();
        audioSource.PlayOneShot(pickUpSFX);
    }

    private void PickUp()
    {
        

        Debug.Log("Picking up " + item.name);
        //Add to inventory and set a result if we did pick it up using a public bool method in Inventory.cs
        bool wasPickedUp = Inventory.instance.Add(item); // here we find and access Inventory.cs script using Singleton
                                                         
        if(wasPickedUp)
        {
            Destroy(gameObject);
        }
        
    }
}
