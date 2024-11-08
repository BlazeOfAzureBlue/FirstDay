using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{


    public event EventHandler<Item> itemSelected;

    float inventoryDebounce = 0;
    bool inventoryActive = false;
    public GameObject inventory; // Reference to the inventory GUI in gamespace
    public GameObject canvas;
    public TMP_Text itemDescHolder;


    public static InventorySystem instance; // Creates new instance of InventorySystem / main instance
    public List<Item> items = new List<Item>();  // Creates a list to store all the items
    public Dictionary<Item, Transform> ItemObjectPairs = new Dictionary<Item, Transform>();

    public Transform ItemContent; // Reference to the content gui in game space
    public Transform InventoryItem; // Reference to the asset of "Item" to be placed in the GUI

    public Camera mainCamera;

    private bool itemContained;

    public void Awake()
    {
        instance = this; // Assigns instance to this class
    }

    public void Update()
    {

        inventoryDebounce -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.I) && inventoryDebounce <= 0) // If I is pressed, checks if the player already has the inventory open. If not, opens it. 
        {
            if (inventoryActive == true)
            {
                inventoryDebounce = 0.5f;
                canvas.SetActive(false);
                inventoryActive = false;

                Cursor.lockState = CursorLockMode.Locked;
                mainCamera.GetComponent<LookCode>().IsGUIActive = false;
                mainCamera.GetComponent<LookCode>().MSensitivityX = 1;
                mainCamera.GetComponent<LookCode>().MSensitivityY = 1;

                ClearItems(); // Clears the items from the inventory GUI to prevent replication
            }
            else
            {
                if(mainCamera.GetComponent<LookCode>().IsGUIActive == false)
                {
                    Cursor.lockState = CursorLockMode.Confined;
                    mainCamera.GetComponent<LookCode>().IsGUIActive = true;
                    mainCamera.GetComponent<LookCode>().MSensitivityX = 0;
                    mainCamera.GetComponent<LookCode>().MSensitivityY = 0;

                    inventoryDebounce = 0.5f;
                    canvas.SetActive(true);
                    inventoryActive = true;
                    ListItems(); // Adds all items to the inventory GUI

                }
                
            }
        }
    }

    public void Add(Item item)
    {
        items.Add(item);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

    public void ClearItems()
    {
        foreach(Transform item in ItemContent) // Goes through content GUI and deletes all items
        {
            Destroy(item.gameObject);
        }
    }

    public bool ContainItem(Item item)
    {
       if (items.Contains(item))
        {
            return true;
        }
       else
        {
            return false;
        }

    }

    public void ListItems()
    {
        foreach (var item in items)
        {

            Transform obj = Instantiate(InventoryItem.transform, ItemContent); // Goes through each item in the list, creating it as an item in the GUI using the previously made GUI model
            var ItemName = obj.transform.Find("ItemName").GetComponent<TMP_Text>(); // Retrieves item name from object
            var ItemIcon = obj.transform.Find("ItemImage").GetComponent<Image>(); // Retrieves the image from the object
            ItemName.text = item.itemName; // Assigns the values to the item GUI object 
            ItemIcon.sprite = item.icon;

            ItemObjectPairs[item] = obj;
            obj.GetComponent<Button>().onClick.AddListener(() => { SelectItem(item); });

        }
    }
    public void SelectItem(Item itemPassed)
    {
        itemDescHolder.text = itemPassed.itemDescription;
        itemSelected?.Invoke(this, itemPassed);
    }
}
