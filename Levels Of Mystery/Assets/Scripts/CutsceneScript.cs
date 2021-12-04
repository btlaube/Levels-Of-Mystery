using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneScript : MonoBehaviour
{
    public Animator animator;
    public Text textElement;
    private bool fullText = false;
    private int index = 0;
    public Player player;

    public string[] texts = {
                        "The year is 1920, and a particularly harsh winter has hit the city of New York in the United States."
                        + "\nSteven Devlin, a retired police officer, had recently taken a job at the opulent Countryshire Apartments as an elevator operator."
                        + "\nA few days later, the owner of the apartment complex, Mr. Lindson, mysteriously died. The police were quick to rule the death as a suicide; however, certain evidence points to the possibility of foul play."
                        + "\nWhat was the true cause of Mr. Lindson’s death? Is a sinister villain hiding among the innocent residents of the apartment complex? It’s up to you to find out…"
                        + "\nTry to solve the case, but be warned: the truth may be steeped in LEVELS OF MYSTERY.", 
                        "Last night, long after the last resident had left the elevator, a tragedy occured. Charles,"
                        + "the groundskeeper of the apartment complex and the father of Mrs. Lindson, died in his sleep."
                        + "The coroner examined the body and determined the death was not a suicide, but that Charles had been" 
                        + "poisoned sometime in the preceding 48 hours." 
                        + "\nThere are six remaining suspects in the apartment complex. Who knows when the killer will strike next?",
                        "Alex, the reporter, was found dead last night in her room, with a writing quill in her hand."
                        + "It looked as if there had been a minimal struggle before her death. A spilled vial of ink stained a paper"
                        + "on the desk, possibly hiding whatever progress she had made towards uncovering the killer."
                        + "It looks like the reporter’s greatest story was that of her own demise. Now that only five suspects"
                        + "remain, there’s no telling what will happen next."
    };

    public void Start() {
        //if (player.day == 1 && player.time == 1){
        //    ShowText();
        //}
        ShowText();
    }

    public void Update() {
        if (Input.GetKeyUp("return") && !fullText) {
            StopAllCoroutines();
            textElement.text = texts[index];
            fullText = true;
        }
        else if (Input.GetKeyUp("return")) {
            HideSelf();
        }
        if (fullText) {
            GameObject.Find("AudioManager").GetComponent<AudioManager>().Stop("Dialogue");
        }
    }

    public void ShowText() {
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

    public void HideSelf() {
        animator.SetTrigger("FadeOut");
        index++;
    }
}
