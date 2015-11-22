using UnityEngine;
using System.Collections;
using System.Collections.Generic;




public class ItemBehaviour : MonoBehaviour
{
    public List<ItemHandler.Item> thisItem = new List<ItemHandler.Item>();

    public GameObject inventoryGameObject;

    public GameObject itemPrefab;

    private GameObject respawn;

    InventoryHandler.InvHandler inventory;

    public void Start()
    {
        inventoryGameObject = GameObject.Find("Inventory");
       
        inventory = inventoryGameObject.GetComponent<InventoryHandler.InvHandler>();

        inventory.items.Add(new ItemHandler.Item(inventory.items.Count, name, "Item", 0, name + ".ico", ItemHandler.Item.ItemType.Single, itemPrefab) );
        
        respawn = GameObject.Find("respawn");

        itemPrefab = Resources.Load("Prefabs/Item") as GameObject;
    }
    public void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {  
            name = gameObject.transform.name;

            //itemHandler.itemsList.Add(new ItemHandler.Item(1, name, "Item", 0, ".ico", ItemHandler.Item.ItemType.Single));
            if(inventory.inventory.Count <= inventory.maxInventory)
            {
                inventory.inventory.Add(new ItemHandler.Item(1, name, "Item", 0, name + ".ico", ItemHandler.Item.ItemType.Single, itemPrefab));
                Debug.Log("Picked up " + name);
           
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Inventory Full!");
            }
        }
    }

    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.name == "Falloff")
        {
            gameObject.transform.position = respawn.transform.position;
        }
    }

    public void pickupItem(string name)
    {

    }
}

    

    


