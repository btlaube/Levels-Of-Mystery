using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseScript : MonoBehaviour
{
    public Animator animator;
    public Text textElement;
    public bool fullText = false;

    public string[] texts;

    public void ShowText(int index) {
        StopAllCoroutines();
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Stop("Dialogue");
        StartCoroutine(TypeDialogue(texts[index]));
    }

    IEnumerator TypeDialogue(string text) {
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Dialogue");
        textElement.text = "";
        foreach (char letter in text.ToCharArray()) {
            textElement.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
        fullText = true;
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Stop("Dialogue");
    }
}
