using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;


public class DialogDisplay : MonoBehaviour
{
    public List<string> Choices;
    public int ChoiceCount;
    public string response;
    public Text textElement;
    public Dialogue Tree = new Dialogue();

    void Start(){
        Tree.LoadDialogue();
        Choices.Add(Tree.CurrentNode.InnerText);
        DisplayChoices();
    }

    public void ChangeChoices(int choice = 0){
        //uses optional parameter choice to update the list of choices. Calls DisplayChoices to update screen.
        if (choice == 0) {
            Choices = Tree.GetNext();
        } else {
            Choices = Tree.GetNext();
        }
        DisplayChoices();
    }

    public void DisplayChoices(){
        //formats Choices list to fit text box. (Theres probably a beter way to do this with unity, but this was what I came up with to display arbitrary amount of options)
        ChoiceCount = Choices.Count;
        textElement.text = "";
        if (ChoiceCount > 1){
            int index = 1;
            foreach (string choice in Choices){
                Debug.Log(choice);
                textElement.text += $"{index} - {choice} \n";
                index+=1;
            }
        } else {
            textElement.text += $"{Choices[0]}";
        }
    }

    void Update(){
        //listens for enter/number key/ to update text box and perform necessary operations.
        int ChoiceCount = Choices.Count; //it is inneficient to count choices text each frame update.
        //Debug.Log(Choices.Count);
        if (ChoiceCount > 1){
            for(int i=1;i<=ChoiceCount;i++) {
                if(Input.GetKeyUp((KeyCode)(48+i))){
                    Debug.Log("you pressed a key");
                    ChangeChoices(i);
                }
            }
        } else if (ChoiceCount == 1){
            if (Input.GetKeyUp("return")){
                Debug.Log("you pressed a key");
                ChangeChoices();
            }
        } else {
            // textElement.text = "end";
        }   
    }
}
