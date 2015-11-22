using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace InventoryHandler
{
    public class InvHandler : MonoBehaviour
    {
        //public GUISkin mainGUISkin;

        public Quaternion playerRotation;

        public List<ItemHandler.Item> items = new List<ItemHandler.Item>(); //Main items database

        public List<ItemHandler.Item> inventory = new List<ItemHandler.Item>(); //Items currently in inventory

        public int maxInventory;

        public static bool showInv = false;

        private GameObject player;

        private GameObject handsObj;

        //private string currentToolTip = "";

        public void Awake()
        {
            player = GameObject.Find("Player");

            handsObj = GameObject.Find("Hands");

            playerRotation = player.transform.localRotation;
        }

        // Use this for initialization
        void Start()
        {
            /*for (int i = 0; i < items.Count; i++)
            {
                items.Add(new ItemHandler.Item());
            }*/
        }
        
        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.I))
                showInv = !showInv;  
        }

        void OnGUI()
        {
            //GUI.skin = mainGUISkin;
            GUI.contentColor = Color.black;

            if (showInv)
            {
                int i = 0; //Used for inventory count

                Event e = Event.current; //Used for mouseOver / mouseClick behavior

               for (int y = 0; y < inventory.Count; y++) //Looks into the inventory list
               {
                    Rect itemRect = new Rect(20, 12 + y * 15, 75, 20); //Declares default rect for items in inventory

                        if (GUI.Button (new Rect (itemRect), inventory[i].itemName, GUI.skin.GetStyle("Label"))) //Creates a button with the label style, and if is clicked functionality //(e.type == EventType.MouseDown && itemRect.Contains (e.mousePosition));
                        {
                            Debug.Log("Dropped (" + inventory[i].itemID + ") " + inventory[i].itemName);

                            //Instantiates Item prefab at 'hands' GameObject position with a random x and z (y)
                            GameObject dropItem = Instantiate(Resources.Load("Item", typeof(GameObject)), new Vector3(handsObj.transform.position.x + Random.Range(-1, 1), handsObj.transform.position.y, handsObj.transform.position.z + Random.Range(-1, 1)), playerRotation) as GameObject;

                            dropItem.GetComponent<ItemBehaviour>().thisItem.Clear(); //Clears list on Item prefab to populate with data from items list

                            dropItem.GetComponent<ItemBehaviour>().thisItem.Add(inventory[i]);

                            dropItem.gameObject.name = inventory[i].itemName;

                            inventory.Remove(inventory[i]); //Removes from inventory list  
                        }
                    i++; //Add label with functionality attached to inventory item
                } 
            }
        }
    }
}
