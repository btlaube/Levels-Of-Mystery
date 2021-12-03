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
    public Text nameTag;
    public Text control;
    public Dialogue Tree = new Dialogue();
    public string Path = "";

    public Player player;
    //public SpriteRenderer npc;
    public Image image; 

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
        //Debug.Log(Path);
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
        nameTag.text = Tree.Character;
        if (Tree.Character == "Steve") {
            control.text = "Number Keys";
        }
        else {
            control.text = "↓ Enter";
        }
        //npc.sprite = Resources.Load<Sprite>(Tree.CharacterPNGPath);//path of image
        image.sprite = Resources.Load<Sprite>(Tree.CharacterPNGPath);
        //image.SetNativeSize();
        if (Tree.Character == "Steve")
        {
            int index = 1;
            textElement.text = "";
            foreach (string choice in Choices.Values)
            {
                //Debug.Log(choice);
                textElement.text += $"{index} - {choice} \n";
                StopAllCoroutines();
                GameObject.Find("AudioManager").GetComponent<AudioManager>().Stop("Dialogue");
                //StartCoroutine(TypeDialogue($"{index} - {choice} \n"));
                index += 1;
            }
        }
        else
        {
            //textElement.text += $"{Choices.ElementAt(0).Value}";
            //textElement.text = "";
            StopAllCoroutines();
            GameObject.Find("AudioManager").GetComponent<AudioManager>().Stop("Dialogue");
            StartCoroutine(TypeDialogue($"{Choices.ElementAt(0).Value}"));
        }
    }

    IEnumerator TypeDialogue(string dialogue) {
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("Dialogue");
        textElement.text = "";
        foreach (char letter in dialogue.ToCharArray()) {
            textElement.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
        GameObject.Find("AudioManager").GetComponent<AudioManager>().Stop("Dialogue");
    }

    void Update()
    {
        //listens for enter/number key/ to update text box and perform necessary operations.
        if (Tree.Character == "Steve")
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
                Debug.Log("end");
                player.UpdateTime();
                player.SavePlayer();
                getPath();
                //Because of Update()'s properties, this will endlessly cycle through all code.
            }
        }
    }
}
