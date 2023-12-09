using System.Collections;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject

{
    new public string name = "New Item"; // name of the item
    public Sprite icon = null; // item icon

    public bool isDefaultItem = false;      //is the item default?




    public virtual void Use()
    {

        //use the item
        //simething might happen

        Debug.Log("Using" + name);
    }




}
