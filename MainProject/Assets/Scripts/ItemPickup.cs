    using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public GameObject interactScreen;
    public GameObject player;


    private bool ItemClose = false;
    void Pickup()
    {
        InventorySystem.instance.Add(item);
        ItemClose = false;
        interactScreen.SetActive(false);
        Destroy(gameObject); // Adds item to the inventory system list then destroys it
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 5)
        {
            print("ok dokie");
            ItemClose = true;

        }
        else
        {
            ItemClose = false;
        }
    }


    private void OnMouseExit()
    {
        interactScreen.SetActive(false);
    }

    private void OnMouseOver()
    {
        print("rah");
        if (ItemClose)
        {
            print("Item Close?");
            interactScreen.SetActive(true);
        }
        else
        {
            interactScreen.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (ItemClose)
        {
            Pickup();
            interactScreen.SetActive(false);
        }
    }
}
