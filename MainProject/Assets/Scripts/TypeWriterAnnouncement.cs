using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypeWriterAnnouncement : MonoBehaviour
{
    private float charactersPerSecond = 20;
    public GameObject TextCanvas;
    public TMP_Text dialogueText;


    public void ActivateTypewriter(string TypeAnnouncement)
    {
        StartCoroutine(TypeText(TypeAnnouncement));
    }
    IEnumerator TypeText(string TypeAnnouncement)
    {
        print("ok");
        TextCanvas.SetActive(true);
        string TypewriterText = null;
        foreach (char Character in TypeAnnouncement)
        {
            TypewriterText += Character;
            dialogueText.text = TypewriterText;
            yield return new WaitForSeconds(1 / charactersPerSecond);
        }

        yield return new WaitForSeconds(3);
        TextCanvas.SetActive(false);
    }
}
