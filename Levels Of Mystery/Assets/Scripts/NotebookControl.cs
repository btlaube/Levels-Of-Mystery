using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NotebookControl : MonoBehaviour
{

    int i = 0;

    public void ButtonExit()
    {
        SceneManager.LoadScene(1);
    }
    public void ButtonNext()
    {
        Text character = GameObject.Find("Canvas/Character Name").GetComponent<Text>();
        character.text = "test1";
        if (i != 8)
        {
            i = i + 1;
        }
    }
    public void ButtonLast()
    {
        if (i != 0)
        {
            i = i - 1;
        }
    }
    public void DiscriptionField()
    {
        /*List<string> people = new List<string>();

        XmlDocument doc = new XmlDocument();
        doc.LoadXml("<xml>discription</xml>");
        foreach (XmlNode node in doc.DocumentElement.ChildNodes){
            string text = node.InnerText;
            people.Add(text);
        }
        foreach(String s in people){
        
        }
        */
    }


}
