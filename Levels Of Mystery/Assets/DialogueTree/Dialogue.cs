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
            Doc.Load(path);
            CurrentNode = Doc.FirstChild.FirstChild; //first element after the root.
            
        }
    }

    public void changeCurrentNode(string address){
        //no references currently, but may be useful for non-dialogue scripts to update nodes if necessary.
        CurrentNode = Doc.SelectSingleNode($"Root/Node[@ID='{address}']");
    }

    public Dictionary<string, string> GetNext(string id){
        CurrentNode = Doc.SelectSingleNode($"Root/Node[@ID='{id}']");
        Dictionary<string, string> options = new Dictionary<string, string>();
        foreach (string address in CurrentNode["Address"].InnerText.Split()){
            XmlNode next = Doc.SelectSingleNode($"Root/Node[@ID='{address}']");
            options.Add(address, next.InnerText);
        }
        return options;
    }
}
