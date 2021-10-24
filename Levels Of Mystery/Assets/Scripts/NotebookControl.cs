using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Xml;


public class NotebookControl : MonoBehaviour
{

    int i = 0;

    XmlDocument personDataXml;

    public void ButtonExit()
    {
        SceneManager.LoadScene(1);
    }
    public void ButtonNext()
    {
        Text Hint1 = GameObject.Find("Canvas/Text Field 1").GetComponent<Text>();
        Hint1.text = "hinttest1";
        if (i != 8)
        {
            i = i + 1;
            ReloadPage();
            Awake();
            DiscriptionField();
        }
    }
    public void ButtonLast()
    {
        if (i != 0)
        {
            i = i - 1;
            ReloadPage();
            Awake();
            DiscriptionField();
        }
    }
    public void Awake()
    {
        TextAsset xmlTextAsset = Resources.Load<TextAsset>("XML/Discriptions");

        personDataXml = new XmlDocument();
        personDataXml.LoadXml(xmlTextAsset.text);
    }
    public void DiscriptionField()
    {
        XmlNode people = personDataXml.SelectSingleNode($"Suspects/Person[@Id='" + i + "']");
        Text Description = GameObject.Find("Canvas/Description Text").GetComponent<Text>();
        Description.text = people.InnerText;
        /*
                XmlNodeList people = personDataXml.SelectNodes("/Suspects/Person[@Id='"+ i +"']");
                foreach (XmlNode Person in people)
                {
                    Text Description = GameObject.Find("Canvas/Description Text").GetComponent<Text>();
                    Description.text = "node test";
                }

                */
        /*List<string> people = new List<string>();

        XmlDocument doc = new XmlDocument();
        doc.LoadXml("Assets\\Resources\\Discription.xml");
        foreach (XmlNode node in doc.DocumentElement.ChildNodes){
            string text = node.InnerText;
            people.Add(text);
        }
        Text DescriptionField = GameObject.Find("Canvas/Description Text").GetComponent<Text>();
        DescriptionField.text = "people(i)";
        */
    }
    public void LoadHint1()
    {
        Text Hint1 = GameObject.Find("Canvas/Text Field 1").GetComponent<Text>();
        Hint1.text = "hinttest1";
    }
    public void LoadHint2()
    {
        Text Hint2 = GameObject.Find("Canvas/Text Field 2").GetComponent<Text>();
        Hint2.text = "hinttest2";
    }
    public void LoadHint3()
    {
        Text Hint3 = GameObject.Find("Canvas/Text Field 3").GetComponent<Text>();
        Hint3.text = "hinttest3";
    }
    public void LoadHint4()
    {
        Text Hint4 = GameObject.Find("Canvas/Text Field 4").GetComponent<Text>();
        Hint4.text = i.ToString();
    }
    public void ReloadPage()
    {
        LoadHint1();
        LoadHint2();
        LoadHint3();
        LoadHint4();
        DiscriptionField();
    }

}
