using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace c_InventoryItem
{ 

    [Serializable]
    public class InventoryItem : MonoBehaviour
    {
        public int itemID;
        
        public string itemName;
        
        public string itemDesc;
        
        public int itemCost;
        
        public string itemIcon;

        public InventoryItemType invType;

        public void Start()
        {
            itemName = gameObject.transform.name;

            itemIcon = itemName + ".ico";

            itemCost = 1;

        }
        public InventoryItem (int id, string name, InventoryItemType type)
        {
            id = itemID + 1;

            name = itemName;

            invType = type;

        }
        public InventoryItem ()
        {

        }

    }

    [System.Serializable]
    public class ItemBase : MonoBehaviour
    {
        public int itemID;

        public string itemName;

        public string itemDesc;

        public int itemCost;

        public string itemIcon;

        public InventoryItemType invType;

    }
    public enum InventoryItemType
    {

        Single = 0,
        Stackable = 1,
        Consumable = 2,
        Equipable = 3

    }

    public interface InventoryHandler
    {
        
        InventoryItemType ItemType { get; }

        
    }


    #region enum types
    public abstract class BaseInventoryItemType
    {

    }

    public class SingleInventoryItem : BaseInventoryItemType, InventoryHandler
    {
        public InventoryItemType ItemType
        {
            get { return InventoryItemType.Single; }
        }
    }

    public class StackableInventoryItem : BaseInventoryItemType, InventoryHandler
    {
        public InventoryItemType ItemType
        {
            get { return InventoryItemType.Stackable; }
        }
    }

    public class ConsumableInventoryItem : BaseInventoryItemType, InventoryHandler
    {
        public InventoryItemType ItemType
        {
            get { return InventoryItemType.Consumable; }
        }
    }

    public class EquipableInventoryItem : BaseInventoryItemType, InventoryHandler
    {
        public InventoryItemType ItemType
        {
            get { return InventoryItemType.Equipable; }
        }
    }
    #endregion
}
