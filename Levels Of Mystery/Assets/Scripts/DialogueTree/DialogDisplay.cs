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
    public string Path = ""; //We will potentially have to use public variables for path, Start() can't take parameters.
    // Assets\\Resources\\Example.xml
    
    //use time/date to pull from table
    //use table to creat interpolated string path
    //load/unload docs after termination of tree.
    public Player player;

    void Start(){
        //restart scene on new tree.
        Debug.Log(player.time);
        getPath();
    }

    public void getPath() {
        //demo
        Debug.Log("getPath ran");
        if (player.day == 1 || true) {
            Debug.Log(player.day);
            if (player.time == 1) {
                Debug.Log(player.time);
                Path = "Assets\\Resources\\Example.xml";
            }
            else if (player.time == 2) {
                Debug.Log(player.time);
                Path = "Assets\\Resources\\example2.xml";
            }
            else {
                Path = "null";
            }
        }
        else {
            Path ="null";
        }
        Debug.Log(Path);
        Tree.LoadDialogue(Path);
        ChangeChoices(Tree.CurrentNode.Attributes["ID"].Value);
    }

    public void ChangeChoices(string choice){
        Choices = Tree.GetNext(choice);
        DisplayChoices();
    }

    public void DisplayChoices(){
        //formats Choices list to fit text box. (Theres probably a beter way to do this with unity, but this was what I came up with to display arbitrary amount of options)
        ChoiceCount = Choices.Count;
        textElement.text = "";
        if (ChoiceCount > 1){
            int index = 1;
            foreach (string choice in Choices.Values){
                Debug.Log(choice);
                textElement.text += $"{index} - {choice} \n";
                index+=1;
            }
        } else if (ChoiceCount == 1) {
            textElement.text += $"{Choices.ElementAt(0).Value}";
        }
    }

    void Update(){
        //listens for enter/number key/ to update text box and perform necessary operations.
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
            if (Tree != null) //checks if we have progressed through at least one tree.
            {
                Debug.Log("tree existed");
                player.UpdateTime();
                getPath();
                //Because of Update()'s properties, this will endlessly cycle through all code.
            }
        }
    }
}
