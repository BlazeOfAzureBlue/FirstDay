using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BatteryInsert : MonoBehaviour
{

    public InventorySystem inventorySystem;
    public GameObject interactScreen;
    public GameObject player;
    public GameObject lightHolder;


    private MeshRenderer mesh;

    public Item requiredItem;

    private bool ItemClose = false;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    private void OnMouseOver()
    {
        if (ItemClose)
        {
            interactScreen.SetActive(true);
        }
        else
        {
            interactScreen.SetActive(false);
        }
    }

    private void ActivateLights()
    {
        print("a");
        for (int i = 0; i < lightHolder.transform.childCount; i++)
        {
            print("ok");
            Transform g = lightHolder.transform.GetChild(i);
            g.GetComponent<Light>().enabled = true;
        }
    }
    private void OnMouseDown()
    {
        if (ItemClose)
        {
            if(inventorySystem.ContainItem(requiredItem))
            {
                mesh.enabled = true;
                inventorySystem.Remove(requiredItem);
                ActivateLights();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 5)
        {
            ItemClose = true;
        }
        else
        {
            ItemClose = false;
        }
    }
}
