using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class DialogDisplay : MonoBehaviour
{
    public Dictionary<string, string> Choices = new Dictionary<string, string>();
    public int ChoiceCount;
    public Text textElement;
    public Dialogue Tree = new Dialogue();

    void Start(){
        Tree.LoadDialogue();
        Choices.Add(Tree.CurrentNode.Attributes["ID"].Value, Tree.CurrentNode.InnerText);
        Debug.Log($"{Choices.Values}, {Choices.Keys}");
        Debug.Log(Choices.Count);
        DisplayChoices();
        
    }

    public void ChangeChoices(string choice){
        Choices = Tree.GetNext(choice);
        DisplayChoices();
    }

    public void DisplayChoices(){
        //formats Choices list to fit text box. (Theres probably a beter way to do this with unity, but this was what I came up with to display arbitrary amount of options)
        ChoiceCount = Choices.Count;
        textElement.text = "";
        if (ChoiceCount > 1){ //remember to change
            int index = 1;
            foreach (string choice in Choices.Values){
                Debug.Log(choice);
                textElement.text += $"{index} - {choice} \n";
                index+=1;
            }
        } else {
            textElement.text += $"{Choices.ElementAt(0).Value}";
        }
    }

    void Update(){
        //listens for enter/number key/ to update text box and perform necessary operations.
        ChoiceCount = Choices.Count; //it  may inneficient to count choices  each frame update.
        if (ChoiceCount > 1){
            for(int i=1;i<=ChoiceCount;i++) {
                if(Input.GetKeyUp((KeyCode)(48+i))){
                    Debug.Log($"you pressed {i}");
                    string id = Choices.ElementAt(i-1).Key;
                    Debug.Log($"chosen id is : {id}");
                    ChangeChoices(id);
                }
            }
        } else if (ChoiceCount == 1){
            if (Input.GetKeyUp("return")){
                Debug.Log("you pressed return");
                string id = Choices.ElementAt(0).Key;
                Debug.Log($"chosen id is : {id}");
                ChangeChoices(id);
            }
        } else {
            textElement.text = "end";
        }   
    }
}
