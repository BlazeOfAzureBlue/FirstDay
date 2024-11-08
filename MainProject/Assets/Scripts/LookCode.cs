using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Timeline.AnimationPlayableAsset;

public class LookCode : MonoBehaviour
{
    public float MSensitivityX;
    public float MSensitivityY;

    public Transform playerBody;

    public bool IsGUIActive = false;

    private float xRotation;
    private float yRotation;

    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        MSensitivityX = 1;
        MSensitivityY = 1;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * MSensitivityX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * MSensitivityY;

        if (IsGUIActive == true)
        {
            Cursor.visible = true;
            xRotation = Mathf.Clamp(xRotation, -18f, 28f);
            yRotation = Mathf.Clamp(yRotation, -115f, -70f);
        }
        else
        {
            Cursor.visible = false;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        }

        yRotation += mouseX;

        xRotation -= mouseY;
        
        
        

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        playerBody.rotation = Quaternion.Euler(0, yRotation, 0);

    }
}

