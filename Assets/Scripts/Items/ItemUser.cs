
using System;
using UnityEngine;

public class ItemUser : Interactable
{
    public GameObject objectToSpawn;
    public GameObject emptyText;
    public Transform spawnPoint;
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip drawerSFX;
    public AudioClip rubySFX;
    //public Item item;
    public float rubiesTaken;
    public float rubiesNeeded;

    private void Start()
    {
        
        
    }
    public override void Interact()
    {
        
            base.Interact();

            TakeItem();
            //SpawnObject();
        

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
                    audioSource.PlayOneShot(rubySFX);
                    rubiesTaken += 1;
                    Debug.Log("Rubies taken:" + rubiesTaken);
                    Inventory.instance.RemoveRuby();
                    

                }
                else
                {
                    audioSource.PlayOneShot(drawerSFX);
                    animator.SetTrigger("Open");
                    objectToSpawn.SetActive(true);
                    //GameObject newObject = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
                    pickUpIndicator.SetActive(false);
                    Inventory.instance.RemoveRuby();
                    canInteract = false;
                    
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
            canInteract = false;
            audioSource.PlayOneShot(drawerSFX);


        }


        

    }
}
