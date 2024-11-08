using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")] // Allows the creation of item objects just from the creation menu
public class Item : ScriptableObject { // Basically the object class for item

    public int id;
    public string itemName;
    public string itemDescription;
    public Sprite icon;
    public string itemType;
    public Transform itemPrefab;   
}
