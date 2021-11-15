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

    public void LoadDialogue(string path)
    {
        Debug.Log($"Loading File: {path}");
        if (File.Exists(path))
        {
            Debug.Log($"File: {path} existed");
            Doc.Load(path);
            CurrentNode = Doc.FirstChild.FirstChild; //first element after the root.
        }
        else { Debug.Log($"File: {path} was not found"); }
    }

    public void changeCurrentNode(string id)
    {
        CurrentNode = Doc.SelectSingleNode($"Root/Node[@ID='{id}']");
        updateCharacter();
        findHint();
    }

    private void findHint()
    {
        if (CurrentNode["Hint"]?.InnerText != null)
        {
            string hint = CurrentNode["Hint"].InnerText;
            Debug.Log(hint);
        }
        else
        {
            Debug.Log("no hint found");
        }
    }

    private void updateCharacter()
    {
        try
        {
            if (Character == CurrentNode.Attributes["Char"].Value) { return; }
            Character = CurrentNode.Attributes["Char"].Value;
            Debug.Log($"char name: {Character}");
        }
        catch (NullReferenceException) { Debug.Log("character not found"); }

        switch (Character)
        {
            case "Player Character":
                Debug.Log("No character.");
                break;
            case "Caroline":
                Debug.Log("No character.");
                break;
            default:
                Debug.Log("No character. Found Speaking.");
                break;
        }
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
                options.Add(address, next.InnerText);
            }
        }
        catch (NullReferenceException) { Debug.Log("CurrentNode has no pointers"); } //Nothing will happen where Address isnt a child element. options will intentionally return empty.
        return options;
    }
}
