using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToOpen : MonoBehaviour
{
    public GameObject interactScreen;
    public GameObject player;
    private Animator doorAnimator;
    private AudioSource audio;

    private bool ItemClose = false;
    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    private void OnMouseOver()
    {
        if (ItemClose)
        {
            interactScreen.SetActive(true);
        }
        else
        {
            interactScreen.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (ItemClose)
        {
            doorAnimator.SetBool("DoorOpened", true);
            audio.Play();
            ItemClose = false;
            interactScreen.SetActive(false);
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 5)
        {
            ItemClose = true;
        }
        else
        {
            ItemClose = false;
        }
    }
}
