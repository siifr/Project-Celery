using UnityEngine;
using System.Collections;

public class ItemHandler : MonoBehaviour 
{
    [System.Serializable]
    public class Item
    {
        public enum ItemType
        {
            Single = 0,
            Stackable = 1,
            Consumable = 2,
            Equipable = 3
        }

        public int itemID;

        public string itemName;

        public string itemDesc;

        public int itemAmount;

        public int itemCost;

        public GameObject itemModel;

        public string itemIcon;

        public ItemType itemType;

        public Item(int id, string name, string desc, int cost, string icon, ItemType type, GameObject model)
        {

            itemName = name;

            itemID = id; //Not implemented

            itemDesc = desc; //Not implemented

            itemCost = cost; //Not implemented

            itemIcon = name + ".ico"; //Not implemented

            itemType = type; //Not implemented

            itemModel = model; //Not implemented 
        }

        public Item() //Blank for resetting
        {

        }
    }
}
