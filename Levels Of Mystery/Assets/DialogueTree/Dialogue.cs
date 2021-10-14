using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

using System.IO;


public class Dialogue
{
    public XmlDocument Doc = new XmlDocument();
    public XmlNode CurrentNode;

    public void LoadDialogue(string path="Assets\\Resources\\Example.xml"){ //may need to be text stream
        if (File.Exists(path)){ 
            //XmlDocument Doc = new XmlDocument();
            Doc.Load(path);
            CurrentNode = Doc.FirstChild.FirstChild; //first element after the root.
            //Debug.Log(CurrentNode.InnerText);
            //CurrentNode =  Doc.SelectSingleNode($"/Root/Node[@ID='{102}']");
        }
    }

    public void changeCurrentNode(string address){
        CurrentNode = Doc.SelectSingleNode($"Root/Node[@ID='{address}']");
    }

    public Dictionary<string, string> GetNext(string id){
        CurrentNode = Doc.SelectSingleNode($"Root/Node[@ID='{id}']");
        Dictionary<string, string> options = new Dictionary<string, string>();
        foreach (string address in CurrentNode["Address"].InnerText.Split()){
            //Debug.Log(address);
            //Debug.Log(Doc);
            XmlNode next = Doc.SelectSingleNode($"Root/Node[@ID='{address}']");
            //Debug.Log($"Root/Node[@ID='{address}']");
            //add conditional here for if node is valid (reputation etc.)
            //Debug.Log(next.InnerText);
            options.Add(address, next.InnerText);
        }
        return options;
    }

    // public void changeCurrentNode(string id){
    //     CurrentNode = Doc.SelectSingleNode($"Node[@ID='{id}']");
    // }
}
