using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInput : MonoBehaviour
{

    private Renderer keyRender;

    [Header("Required Scripts")]
    public KeypadInteraction keypad;

    [Header("Material Components")]
    public Material NonPressedMaterial;
    public Material PressedMaterial;
    public Material HoveredMaterial;

    // Start is called before the first frame update
    void Start()
    {
        keyRender = GetComponent<Renderer>();
    }

    private void OnMouseEnter()
    {
        if(keypad.KeypadActive)
        {
            keyRender.material = HoveredMaterial;
        }
    }

    private void OnMouseExit()
    {
        if(keypad.KeypadActive)
        {
            keyRender.material = NonPressedMaterial;
        }    
    }

    private void OnMouseDown()
    {
        if(keypad.KeypadActive)
        {
            keyRender.material = PressedMaterial;
            keypad.EnterKey(transform.name);
            StartCoroutine(ResetKey());
        }
    }

    private IEnumerator ResetKey()
    {
        yield return new WaitForSeconds(0.2f);
        keyRender.material = NonPressedMaterial;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
