using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogDisplay : MonoBehaviour
{
    public List<string> Choices; //Lists may need to be stored as dict, id:val
    public int ChoiceCount;
    public string response;
    public Text textElement;


    void Start(){
        textElement.text = response;
    }

    public void ChangeChoices(int choice = 0){
        //uses optional parameter choice to update the list of choices. Calls DisplayChoices to update screen.
        if (choice == 0){
            //Choices = Dialogue.GetNext()
        } else {
            //Choices = Dialogue.GetNext(choice)
        }
        DisplayChoices();
    }

    public void DisplayChoices(){
        //formats Choices list to fit text box. (Theres probably a beter way to do this with unity, but this was what I came up with to display arbitrary amount of options)
        ChoiceCount = Choices.Count;
        int index = 1;
        textElement.text = "";
        foreach (string choice in Choices){
            textElement.text += $"{index} : {choice} \n";
            ++index;
        }
    }

    void Update(){
        //listens for enter/number key/ to update text box and perform necessary operations.
        int ChoiceCount = Choices.Count; //it is inneficient to count choices text each frame update.
        if (ChoiceCount > 1){
            for(int i=1;i<=ChoiceCount;i++) {
                if(Input.GetKeyUp((KeyCode)(48+i))){
                    ChangeChoices(i);
                }
            }
        } else if (ChoiceCount == 1){
            if (Input.GetKeyUp("return")){
                ChangeChoices();
            }
        } else {
            textElement.text = "end";
        }
            
    }
}
