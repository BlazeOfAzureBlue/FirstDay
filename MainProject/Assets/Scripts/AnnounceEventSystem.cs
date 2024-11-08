using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnounceEventSystem : MonoBehaviour
{

    public TypeWriterAnnouncement TypeWriterScript;
    private BoxCollider boxcollider;

    private void Start()
    {
        boxcollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            TypeWriterScript.ActivateTypewriter("THIS IS THE GREATEST PLAAAAAAAAAN");
        }
    }
}
