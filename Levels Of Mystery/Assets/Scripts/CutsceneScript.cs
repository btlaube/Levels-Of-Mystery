using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneScript : MonoBehaviour
{
    public Animator animator;
    public Text textElement;
    public bool fullText = false;
    public int index = 0;
    public Player player;

    public string[] texts;

    public GameObject alexButton;
    public GameObject alexX;

    public void OnEnable() {
        if (player.day == 1 && player.time == 1) {
            index = 0;
        }
        ShowText();
    }

    public void Update() {
        if (Input.GetKeyUp("return") && !fullText) {
            StopAllCoroutines();
            textElement.text = texts[index];
            fullText = true;
        }
        else if (Input.GetKeyUp("return")) {
            FadeOut();
        }
        if (fullText) {
            GameObject.Find("AudioManager").GetComponent<AudioManager>().Stop("Dialogue");
        }
    }

    public void ShowText() {
        StopAllCoroutines();
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Stop("Dialogue");
        StartCoroutine(TypeDialogue(texts[index]));
        if (index == 2) {
            alexX.SetActive(true);
            alexButton.GetComponent<Button>().interactable = false;
        }
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

    public void FadeOut() {        
        animator.SetTrigger("FadeOut");
        GameObject.Find("CanvasGroup").GetComponent<CanvasGroupScript>().ContinueGame();
        index++;
    }

    public void HideSelf() {
        gameObject.SetActive(false);
        textElement.text = "";
        fullText = false;
    }
}
