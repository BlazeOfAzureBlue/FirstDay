using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    private Animator doorAnimator;
    
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }

    public void OpeenDoor()
    {
        doorAnimator.SetBool("DoorOpened", true);
    }
}
