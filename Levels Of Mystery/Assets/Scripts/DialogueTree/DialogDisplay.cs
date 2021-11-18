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
    public string Path = "";

    public Player player;
    public SpriteRenderer npc; 

    void Start()
    {
        //restart scene on new tree.
        //Debug.Log(player.time);
        getPath();
    }

    public void getPath()
    {
        if (player.day == 10) //arbitrary
        {
            Tree = null; //will cause error, only for testing
        }
        Path = $"Assets\\Resources\\{player.day}-{player.time}.xml"; //EX: "Assets\\Resources\\1-2.xml"
        Debug.Log(Path);
        Tree.LoadDialogue(Path);
        ChangeChoices(Tree.CurrentNode.Attributes["ID"].Value);
    }

    public void ChangeChoices(string choice)
    {
        Choices = Tree.GetNext(choice);
        DisplayChoices();
    }

    public void DisplayChoices()
    {
        //formats Choices list to fit text box. (Theres probably a beter way to do this with unity, but this was what I came up with to display arbitrary amount of options)
        ChoiceCount = Choices.Count;
        textElement.text = "";
        npc.sprite = Resources.Load<Sprite>(Tree.CharacterPNGPath);//path of image
        if (ChoiceCount > 1)
        {
            int index = 1;
            foreach (string choice in Choices.Values)
            {
                Debug.Log(choice);
                textElement.text += $"{index} - {choice} \n";
                index += 1;
            }
        }
        else if (ChoiceCount == 1)
        {
            textElement.text += $"{Choices.ElementAt(0).Value}";
        }
    }

    void Update()
    {
        //listens for enter/number key/ to update text box and perform necessary operations.
        if (ChoiceCount > 1)
        {
            for (int i = 1; i <= ChoiceCount; i++)
            {
                if (Input.GetKeyUp((KeyCode)(48 + i)))
                {
                    string id = Choices.ElementAt(i - 1).Key;
                    ChangeChoices(id);
                }
            }
        }
        else if (ChoiceCount == 1)
        {
            if (Input.GetKeyUp("return"))
            {
                string id = Choices.ElementAt(0).Key;
                ChangeChoices(id);
            }
        }
        else
        {
            textElement.text = "end";
            if (Tree != null) //checks if we have progressed through at least one tree.
            {
                Debug.Log("tree existed");
                player.UpdateTime();
                player.SavePlayer();
                getPath();
                //Because of Update()'s properties, this will endlessly cycle through all code.
            }
        }
    }
}
