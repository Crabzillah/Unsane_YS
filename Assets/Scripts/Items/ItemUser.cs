
using System;
using UnityEngine;

public class ItemUser : Interactable
{
    public GameObject objectToSpawn;
    public Transform spawnPoint;
    public Animator animator;
    //public Item item;
    public float rubiesTaken;
    public float rubiesNeeded;
    public override void Interact()
    {
        base.Interact();

        TakeItem();
        SpawnObject();
    }

    private void TakeItem()
    {

        
        //Debug.Log("Picking up " + item.name);
        //Add to inventory and set a result if we did pick it up using a public bool method in Inventory.cs
        Inventory.instance.CheckForRubies();
        Debug.Log("Checkin for rubies sent from ItemUser");

        // here we find and access Inventory.cs script using Singleton

        if (Inventory.instance.canTakeRuby == true)
        {
            if (rubiesTaken != rubiesNeeded)
            {
                rubiesTaken += 1;
                Debug.Log("Rubies taken:" + rubiesTaken);
                Inventory.instance.RemoveRuby();

            }
            

            



        }






    }

    private void SpawnObject()
    {
        if( rubiesTaken == rubiesNeeded)
        {
            animator.SetTrigger("Open");
            objectToSpawn.SetActive(true);
            //GameObject newObject = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
            pickUpIndicator.SetActive(false);
            Inventory.instance.RemoveRuby();
            Destroy(this);
        }


        

    }
}
