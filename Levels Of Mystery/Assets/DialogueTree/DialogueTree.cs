using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
 


namespace System.Xml
{
    public class DialogueTree {

        public void Main(string path){
            XmlDocument doc = LoadDialogue(path);
        }
        
        /*
        string currentNode(int id, XmlDocument doc){
            return doc.XmlText($"/ExampleTree/Node[@ID={id}]");
        }
        */

        /*
        List<XmlNodeList> nextNodes(int id, XmlDocument doc) {
            int[] addresses = doc.XmlText($"/ExampleTree/Node[@ID={id}]/Address").Split();
            List<XmlNodeList> nextNodes; 
            foreach (int i in addresses)
            {
                nextNodes.Append(XmlSelectNodes($"/ExampleTree/Node[@ID={id}]/Address"));
            }
            return nextNodes;
        }
        */
        XmlDocument LoadDialogue(string path){
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            return doc;
  
            //XmlNodeList List of Nodes (often elements but could be anything)
            //XmlElement: <element></element>
            //XmlAttribute: attribute="x" (mutliple indexable like array)
            //XmlText: the gooey stuff in the middle of elements.
            //XmlSelectSingleNode
            //XmlSelectNodes
            //Require NET 5, if not compatible with Unity, can parse with custom Node Class
            //Potentially bad practice due to XmlNodeList easily overwriting XML Files
        }
    }

} 
