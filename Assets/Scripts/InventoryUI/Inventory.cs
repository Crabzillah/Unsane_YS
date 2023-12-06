using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;

        Cursor.lockState = CursorLockMode.Locked;
    }

    #endregion

    //we create an event that we can subscribe different methods to, when we then trigger the event then all the subscribed methods will be called.

    public delegate void OnItemChanged(); //defined our Delegate type
    public OnItemChanged OnItemChangedCallback; //implementing the delegate

    public int space = 15;    // limiting inventory space


    public List<Item> items = new List<Item>(); //created an item list

    public bool canTakeRuby = false;
    

    public bool haveKey = false;

    public bool inventoryActive = false;


    public bool Add (Item item)
    {
        //add this item to the items list IF its not a default item
        if (!item.isDefaultItem)
        {

            if (items.Count >= space) // check if we have enough items in inventory
            {
                Debug.Log("Not enough space");
                return false;
            }
            
            items.Add(item);

            if (OnItemChangedCallback != null) //we check if we have some method subscribed to this callback
            {
                OnItemChangedCallback.Invoke(); //triggering the event so we want to our UI updated
            }
            

        }

        return true;
        
        
    }

    public void CheckForKey()
    {
        foreach (Item item in items)
        {
            Debug.Log("check for key foreach STARTED");
            if (item.name == "Key")
            {
                Debug.Log("Found key in Inventory");
                haveKey = true;
                Debug.Log("CAN TAKE SET TO:" + Inventory.instance.haveKey);


            }



        }



    }

    public void RemoveKey()
    {
        foreach (Item item in items)
        {
            if (item.name == "Key")
            {
                Debug.Log("key removed.");
                Remove(item);
                haveKey = false;
            }
        }
    }

    public void CheckForRubies()
    {
        foreach(Item item in items)
        {
            Debug.Log("foreach STARTED");
            if (item.name == "Red Ruby")
            {
                Debug.Log("Found ruby in Inventory");
                canTakeRuby = true;
                Debug.Log("CAN TAKE SET TO:" + Inventory.instance.canTakeRuby);


            }
            
         

        }

     

    }    

    public void RemoveRuby()
    {
        foreach(Item item in items)
        {
            if(item.name == "Red Ruby")
            {
                Debug.Log("ruby removed.");
                Remove(item);
                canTakeRuby = false;
            }
        }
    }
    public void Remove(Item item)
    {
        //remove this item from our item list
        items.Remove(item);
        if (OnItemChangedCallback != null) //we check if we have some method subscribed to this callback
        {
            OnItemChangedCallback.Invoke(); //triggering the event so we want to our UI updated
        }
        Debug.Log("RemovedItem!!!");
    }

}
