using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.IO;


public class Dialogue
{
    public XmlDocument Doc = new XmlDocument();
    public XmlNode CurrentNode;
    public List<string> NextChoices;

    public void LoadDialogue(string path="Assets\\Resources\\Example.xml"){ //may need to be text stream
        if (File.Exists(path)){ 
            //XmlDocument Doc = new XmlDocument();
            Doc.Load(path);
            CurrentNode = Doc.FirstChild.FirstChild; //first element after the root.
            Debug.Log(CurrentNode.InnerText);
            //CurrentNode =  Doc.SelectSingleNode($"/Root/Node[@ID='{102}']");
        }
    }

    public List<string> GetNext(){
        List<string> options = new List<string>();
        foreach (string address in CurrentNode["Address"].InnerText.Split()){
            Debug.Log(address);
            Debug.Log(Doc);
            XmlNode next = Doc.SelectSingleNode($"Root/Node[@ID='{address}']");
            Debug.Log($"Root/Node[@ID='{address}']");
            //add conditional here for if node is valid (reputation etc.)
            Debug.Log(next.InnerText);
            options.Add(next.InnerText);
        }
        return options;
    }

    public void changeCurrentNode(string id){
        CurrentNode = Doc.SelectSingleNode($"Node[@ID='{id}']");
    }
}
