using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml;
using System.IO;


public class Dialogue
{
    public XmlDocument Doc = new XmlDocument();
    public XmlNode CurrentNode;
    public string Character = "None";
    public string NPC1PNGPath = "None";
    public string NPC2PNGPath = "None";
    public Player player; 

    public void LoadDialogue(string path)
    {
        while (true)
        {
            if (File.Exists(path))
            {
                Debug.Log($"path exists: {path}");
                Doc.Load(path);
                CurrentNode = Doc.FirstChild.FirstChild; //first element after the root.
                //updateCharacter(CurrentNode);
                break;
            }
            else { 
                Debug.Log($"File: {path} was not found"); 
                player.UpdateTime(); //hacky but quick solution
            }
            
        }
    }

    public void changeCurrentNode(string id)
    {
        CurrentNode = Doc.SelectSingleNode($"Root/Node[@ID='{id}']");
        //updateCharacter();
        findHint();
    }

    private void findHint()
    {
        if (CurrentNode["Hint"]?.InnerText != null)
        {
           string character = CurrentNode.Attributes["Char"].Value;
           string hint = CurrentNode["Hint"].InnerText;
           player.AddHint(character, hint);
        }
        else
        {
            //Debug.Log("no hint found");
        }
    }

    private void updateCharacter(XmlNode node)
    {

        //Character = node.Attributes["Char"].Value;
        //NPC1PNGPath = "CharacterSprites\\" + node["NPC1"].InnerText;
        //if (node["NPC2"].InnerText == "") {
        //    NPC2PNGPath = "CharacterSprites\\Transparent";
        //}
        //else {
        //    NPC2PNGPath = "CharacterSprites\\" + node["NPC2"].InnerText;
        //}        

        if (node != null) {
            Debug.Log("node is not null");
        }
        else {
            Debug.Log("node is null");
        }
        try
        {
            if (Character == node.Attributes["Char"].Value) { return; }
            Character = node.Attributes["Char"].Value;
            //temp = Character;
        }
        catch (NullReferenceException) { Debug.Log("character not found"); }
        
        Debug.Log("hello" + node.Attributes["ID"].Value);
        if (node.Attributes["ID"].Value == "100"){
            NPC1PNGPath = "CharacterSprites\\" + node.Attributes["NPC1"].Value;
            if (node.Attributes["NPC2"].Value == "") {
                NPC2PNGPath = "CharacterSprites\\Transparent";
            }
            else {
                NPC2PNGPath = "CharacterSprites\\" + node.Attributes["NPC2"].Value;
            }  
        }
        

        //Debug.Log("npc1:");
        //Debug.Log("CharacterSprites\\" + node["NPC1"].InnerText);

        //switch (Character)
        //{
        //    case "Player Character":
        //        break;
        //    case "Caroline":
        //        NPC1PNGPath = "CharacterSprites\\Caroline";
        //        break;
        //    case "Charles":
        //        NPC1PNGPath = "CharacterSprites\\Charles";
        //        break;
        //    case "Virginia":
        //        NPC1PNGPath = "CharacterSprites\\VirginiaTemp";
        //        break;
        //    case "Lucy":
        //        NPC1PNGPath = "CharacterSprites\\Lucy";
        //        break;
        //    case "Thomas":
        //        NPC1PNGPath = "CharacterSprites\\Thomas";
        //        break;
        //    case "James":
        //        NPC1PNGPath = "CharacterSprites\\James";
        //        break;
        //    case "Alex":
        //        NPC1PNGPath = "CharacterSprites\\AlexTemp";
        //        break;
        //    case "Stranger":
        //        NPC1PNGPath = "CharacterSprites\\Stranger";
        //        break;
        //    default:
        //        Debug.Log("No character. Found Speaking.");
        //        break;
        //}
    }

    public Dictionary<string, string> GetNext(string id)
    {
        changeCurrentNode(id);
        Dictionary<string, string> options = new Dictionary<string, string>();
        try
        {
            foreach (string address in CurrentNode["Address"].InnerText.Split())
            {
                XmlNode next = Doc.SelectSingleNode($"Root/Node[@ID='{address}']/Text");
                Debug.Log(CurrentNode.Attributes["ID"].Value);
                //if (CurrentNode.Attributes["ID"].Value == "0") {
                //    Debug.Log("update character");
                //    Debug.Log(Doc.SelectSingleNode($"Root/Node[@ID='{address}']"));
                //    //updateCharacter(Doc.SelectSingleNode($"Root/Node[@ID='{address}']"));
                //}
                updateCharacter(Doc.SelectSingleNode($"Root/Node[@ID='{address}']"));
                options.Add(address, next.InnerText);
            }
        }
        catch (NullReferenceException) { Debug.Log("CurrentNode has no pointers"); } //Nothing will happen where Address isnt a child element. options will intentionally return empty.
        return options;
    }
}
