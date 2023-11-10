using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUI : MonoBehaviour
{

    public Transform itemsParent;
    public GameObject inventoryUI;

    

   // public GameObject player;

    //public Component playerInputs;

    Inventory inventory;

    InventorySlot[] slots; //creating an array of inventory slots

    // Start is called before the first frame update
    void Start()
    {
       // playerInputs = player.GetComponent("StarterAssetsInputs");

        inventory = Inventory.instance;

        inventory.OnItemChangedCallback += UpdateUI; // Here we subscribe UpdateUI method to our event, so whenever we add item to our inventory we also update ui

        slots = itemsParent.GetComponentsInChildren<InventorySlot>(); // if we will need to change slots dynamically, we can put this into update UI method
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            //make mouse visible.
            if (inventoryUI.activeSelf == true)
            {
                inventory.inventoryActive = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                inventory.inventoryActive = false;

            }


        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++) //we loop through all of our slots with the length
        {
            if (i < inventory.items.Count) // if there are more items to add,
                slots[i].AddItem(inventory.items[i]); // and add item on that slot and pass in the corresponding items array
            else //if we dont have anymore items to add
            {
                slots[i].ClearSlot(); // then we clear the slot
            }
        }

        Debug.Log("Updating UI");
    }    
}
