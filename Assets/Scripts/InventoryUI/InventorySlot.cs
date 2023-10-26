using UnityEngine;
using UnityEngine.UI;


public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    public GameObject rubyText;
    public GameObject fileText;
    public GameObject pillText;

    Item item; //this variable will keep track of the current item in the slot

    //private bool showRubyText = false;

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot ()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Debug.Log("RemovingITEM");
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if(item != null)
        {
            if (item.name == "Red Ruby")
            {
                item.Use();

                rubyText.SetActive(!rubyText.activeInHierarchy); // activate/deactivate ruby description text panel
                fileText.SetActive(false);
                pillText.SetActive(false);


            }
            if (item.name == "File")
            {
                item.Use();

                fileText.SetActive(!fileText.activeInHierarchy); // activate/deactivate ruby description text panel
                pillText.SetActive(false);
                rubyText.SetActive(false);

            }
            if (item.name == "Pill")
            {
                item.Use();

                pillText.SetActive(!pillText.activeInHierarchy); // activate/deactivate ruby description text panel
                rubyText.SetActive(false);
                fileText.SetActive(false);

            }

        }
    }



}
