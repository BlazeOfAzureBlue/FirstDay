using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public LookCode lookCode;
    public GameObject MainMenu;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        lookCode.MSensitivityX = 0;
        lookCode.MSensitivityY = 0;
        lookCode.IsGUIActive = true;
    }
    public void StartGame()
    {
        lookCode.IsGUIActive = false;
        MainMenu.SetActive(false);
        lookCode.StartGame();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
