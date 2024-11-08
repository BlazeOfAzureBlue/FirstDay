using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemObserver : MonoBehaviour, IDragHandler {

    [SerializeField] private InventorySystem inventorySystem;

    private Transform itemPrefab;

    private void Start()
    {
        inventorySystem.itemSelected += InventorySystem_itemSelected;
    }
    private void InventorySystem_itemSelected(object sender, Item itemSelected)
    {
        if(itemPrefab != null)
        {
            Destroy(itemPrefab.gameObject);
        }
        itemPrefab = Instantiate(itemSelected.itemPrefab, new Vector3(1000,1000,1000), Quaternion.identity);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Vector3.Dot(itemPrefab.transform.up, Vector3.up) >= 0 && itemPrefab != null) 


            {

            itemPrefab.transform.eulerAngles += new Vector3(-eventData.delta.y, -eventData.delta.x, 0);

        }


            else

        {

            itemPrefab.transform.eulerAngles += new Vector3(eventData.delta.y, eventData.delta.x, 0);

        }
    }
}
