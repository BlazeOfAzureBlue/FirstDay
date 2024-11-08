using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotePickup : MonoBehaviour
{

    public string DocumentText = "";
    public GameObject document;
    public TMP_Text documenttext;
    public Item item;
    public GameObject interactScreen;
    public GameObject player;

    private bool ObjectClose = false;
    private bool DocumentActive = false;
    // Start is called before the first frame update

    void Pickup()
    {
        InventorySystem.instance.Add(item);
        Destroy(gameObject); // Adds item to the inventory system list then destroys it
    }

    private void OnMouseDown()
    {
        if (ObjectClose)
        {
            document.SetActive(true);
            DocumentText = DocumentText.Replace("\n", "\n");
            documenttext.text = DocumentText;
            interactScreen.SetActive(false);
            DocumentActive = true;  
        }
    }

    private void OnMouseOver()
    {
        if (ObjectClose)
        {
            interactScreen.SetActive(true);
        }
        else
        {
            interactScreen.SetActive(false);
        }
    }

    private void OnMouseExit()
    {
        interactScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && DocumentActive == true)
        {
            document.SetActive(false);
            Pickup();
            interactScreen.SetActive(false);
        }

        if (Vector3.Distance(transform.position, player.transform.position) < 10)
        {
            ObjectClose = true;
        }
        else
        {
            ObjectClose = false;
        }
    }
}
