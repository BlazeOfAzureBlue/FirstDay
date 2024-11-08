using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoxPuzzleCode : MonoBehaviour
{

    public Button NumberOneUp;
    public Button NumberTwoUp;
    public Button NumberThreeUp;
    public Button NumberOneDown;
    public Button NumberTwoDown;
    public Button NumberThreeDown;
    public Button ExitButton;
    public TMP_Text NumberOne;
    public TMP_Text NumberTwo;
    public TMP_Text NumberThree;
    public Canvas canvas;

    public Camera mainCamera;

    int numberOne = 0;
    int numberTwo = 0;
    int numberThree = 0;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) // If I is pressed, checks if the player already has the inventory open. If not, opens it. 
        {
            Cursor.lockState = CursorLockMode.Confined;
            //mainCamera.GetComponent<LookCode>().MouseSensitivity = 0;
        }
    }

    private void Awake()
    {
        NumberOne.text = numberOne.ToString();
        NumberTwo.text = numberTwo.ToString();
        NumberThree.text = numberThree.ToString();
        NumberOneUp.onClick.AddListener(delegate { ActivateButtonMovement("UpNumberOne"); });
        NumberOneDown.onClick.AddListener(delegate { ActivateButtonMovement("DownNumberOne"); });
        NumberTwoUp.onClick.AddListener(delegate { ActivateButtonMovement("UpNumberTwo"); });
        NumberTwoDown.onClick.AddListener(delegate { ActivateButtonMovement("DownNumberTwo"); });
        NumberThreeUp.onClick.AddListener(delegate { ActivateButtonMovement("UpNumberThree"); });
        NumberThreeDown.onClick.AddListener(delegate { ActivateButtonMovement("DownNumberThree"); });
        ExitButton.onClick.AddListener(CloseScreen);

    }

    private void CloseScreen()
    {
        canvas.enabled = false;
    }
    private void ActivateButtonMovement(string buttonPressed)
    {
        switch (buttonPressed)
        {
            case "UpNumberOne":
                if(numberOne == 9)
                {
                    numberOne = 0;
                }
                else
                {
                    numberOne++;
                }
                break;
            case "DownNumberOne":
                if(numberOne == 0)
                {
                    numberOne = 9;
                }
                else
                {
                    numberOne--;
                }
                break;
            case "UpNumberTwo":
                if(numberTwo == 9)
                {
                    numberTwo = 0;
                }
                else
                {
                    numberTwo++;
                }
                break;
            case "DownNumberTwo":
                if(numberTwo == 0)
                {
                    numberTwo = 9;
                }
                else
                {
                    numberTwo--;
                }
                break;
            case "UpNumberThree":
                if(numberThree == 9)
                {
                    numberThree = 0;
                }
                else
                {
                    numberThree++;
                }
                break;
            case "DownNumberThree":
                if (numberThree == 0)
                {
                    numberThree = 9;
                }  
                else
                {
                    numberThree--;
                }
                break;
        }
        NumberOne.text = numberOne.ToString();
        NumberTwo.text = numberTwo.ToString();
        NumberThree.text = numberThree.ToString();
    }
}
