using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceActivation : MonoBehaviour
{
    private BoxCollider boxcollider;
    private AudioSource audio;
    public TypeWriterAnnouncement TypeWriterScript;

    private bool AlreadyPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        boxcollider = GetComponent<BoxCollider>();
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(AlreadyPlayed == false && other.transform.name == "Player")
        {
            audio.Play();
            TypeWriterScript.ActivateTypewriter("It has been noted that Nothing There has escaped containment. All capable agents are to deal with this.");
            AlreadyPlayed = true;
        }
    }
}
