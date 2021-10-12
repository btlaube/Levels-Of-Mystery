using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.IO;


public class Dialogue
{
    public XmlDocument Doc;
    public XmlNode CurrentNode;

    public void LoadDialogue(string path="Assets\\Resources\\Example.xml"){ //may need to be text stream
        if (File.Exists(path)){ 

            XmlDocument Doc = new XmlDocument();
            Doc.Load(path);
            CurrentNode = Doc.FirstChild.FirstChild; //first element after the root.
            CurrentNode = Doc.SelectSingleNode
            //Debug.Log(CurrentNode.InnerText); //the problem child.
        }
    }

    public List<string> nextNodes(){
        List<string> options = new List<string>();
        foreach (string address in CurrentNode["Address"].InnerText.Split()){
            XmlNode next = Doc.SelectSingleNode($"Node[@ID='{address}']");
            //add conditional here for if node is valid (reputation etc.)
            options.Add(next.InnerText);
        }
        return null;
    }

    public void changeCurrentNode(string id){
        CurrentNode = Doc.SelectSingleNode($"Node[@ID='{id}']");
    }
    
    // class DialogueNode
    // {
    //     public string ID { get; private set;}
    //     public string Quote { get; private set;}
    //     public List<string> Addresses { get; private set;}

    //     public DialogueNode(XmlNode CurrentNode){

    //         ID = CurrentNode.Attributes["ID"].Value;
    //         Quote = CurrentNode.InnerText;
    //         foreach (string address in CurrentNode["Address"].InnerText.Split()){
    //             Addresses.Add(address);
    //         }

    //     }
    // }
}
