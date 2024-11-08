using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Security;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class KeypadInteraction : MonoBehaviour
{
    [Header("Required Game Objects")]
    public Camera playerCamera;
    public GameObject KeypadCamera;
    public TMP_Text keypadText;
    public GameObject InteractScreen;
   // public GameObject;
    public GameObject player;
    public GameObject CameraHolder;
    public GameObject exitKeypad;
    public GameObject EndScreen;

    [Header("Required Materials")]
    public Material incorrectMaterial;
    public Material correctMaterial;
    public Material regularMaterial;

    public bool KeypadActive;
    public string KeypadCode;

    private string InputtedCode = "ENTER";
    private bool ObjectClose = false;
    private BoxCollider keypadCollider;
    private string[] values = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

    public LookCode lookCode;

    private void Start()
    {
        keypadCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 10)
        {
            ObjectClose = true;
        }
        else
        {
            ObjectClose = false;
        }

        if(Input.GetKeyDown(KeyCode.F) && KeypadActive == true)
        {
            KeypadActive = false;
            lookCode.IsGUIActive = false;
            StartCoroutine(MoveCamera());
            keypadCollider.enabled = true;
            exitKeypad.SetActive(false);
        }
    }
    private void OnMouseDown()
    {
        if (playerCamera.transform.position != KeypadCamera.transform.position && ObjectClose && lookCode.IsGUIActive == false)
        {
            KeypadActive = true;
            StartCoroutine(MoveCamera());
            lookCode.IsGUIActive = true;
            InteractScreen.SetActive(false);
            keypadCollider.enabled = false;
            exitKeypad.SetActive(true);
            UpdateScreen();
            if(InputtedCode == "ENTER")
            {
                InputtedCode = "";
            }    
        }
    }

    private void OnMouseOver()
    {
        if (ObjectClose && KeypadActive == false)
        {
            InteractScreen.SetActive(true);
        }
        else
        {
            InteractScreen.SetActive(false);
        }
    }

    private void OnMouseExit()
    {
        InteractScreen.SetActive(false);
    }

    private void UpdateScreen()
    {
        keypadText.text = InputtedCode;
    }
    public void EnterKey(string input)
    {
        switch (input)
        {
            case "Clear":
                InputtedCode = "";
                UpdateScreen();
                break;
            case "Enter":
                if (InputtedCode == KeypadCode)
                {
                    InputtedCode = "GRANTED";
                    UpdateScreen();
                    InputtedCode = "";
                    StartCoroutine(SetMaterial("Correct"));
                    exitKeypad.SetActive(false);
                    EndScreen.SetActive(true);

                }
                else
                {
                    InputtedCode = "DENIED";
                    UpdateScreen();
                    InputtedCode = "";
                    StartCoroutine(SetMaterial("Denied"));
                }
                break;
            case "Back":
                InputtedCode = InputtedCode.Remove(InputtedCode.Length - 1);
                UpdateScreen();
                break;
            default:
            if (InputtedCode.Length == 4)
            {
                keypadText.text = "FULL";
            }
            else
            {
                InputtedCode = InputtedCode + input;
                    UpdateScreen();
            }
                break;
        }
    }

    private IEnumerator MoveCamera()
    {
        // check the distance and see if we still need to move towards the destination 
        if(KeypadActive == true)
        {
            while (Vector3.Distance(playerCamera.transform.position, KeypadCamera.transform.position) > 0.01f)
            {
                playerCamera.transform.parent = null;
                playerCamera.transform.position = Vector3.MoveTowards(playerCamera.transform.position, KeypadCamera.transform.position, Time.deltaTime * 5);
                //playerCamera.transform.rotation = playerCamera.transform.rotation * Quaternion.Euler(0, 270f, 0f);
                // Return  nothing meaningful and wait until next frame​
                yield return null;
            }
        }
        else
        {
            while (Vector3.Distance(playerCamera.transform.position, CameraHolder.transform.position) > 0.01f)
            {
                playerCamera.transform.parent = CameraHolder.transform;
                playerCamera.transform.position = Vector3.MoveTowards(playerCamera.transform.position, CameraHolder.transform.position, Time.deltaTime * 5);
                //playerCamera.transform.rotation = playerCamera.transform.rotation * Quaternion.Euler(0, 270f, 0f);
                // Return  nothing meaningful and wait until next frame​
                yield return null;
            }
        }
    }

    private IEnumerator SetMaterial(string Type)
    {
        Renderer[] objectChildren;
        objectChildren = transform.GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in objectChildren)
        {
            if (values.Contains(rend.gameObject.name))
            {
                if (Type == "Correct")
                {
                    rend.material = correctMaterial;
                }
                else
                {
                    rend.material = incorrectMaterial;
                }

            }
        }
        yield return new WaitForSeconds(0.5f);
        foreach (Renderer rend in objectChildren)
        {
            if (values.Contains(rend.gameObject.name))
            {
                rend.material = regularMaterial;

            }
        }

        yield return null;
    }
}

