using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Xml;
using System.Xml.XPath;


public class NotebookControl : MonoBehaviour
{
    
    private int i = 0;

    public XmlDocument personDataXml;

    public void ButtonExit()
    {
        SceneManager.LoadScene(1);
    }
    public void ButtonNext()
    {
        Text Hint1 = GameObject.Find("NotebookCanvas/Text Field 1").GetComponent<Text>();
        Hint1.text = "hinttest1";
        if (i != 7)
        {
            i = i + 1;
            ReloadPage();
        }
    }
    public void ButtonLast()
    {
        if (i != 0)
        {
            i = i - 1;
            ReloadPage();
        }
    }
    public void CharacterName()
    {
        
        if (i == 0)
        {
            Text CharacterName = GameObject.Find("NotebookCanvas/Character Name").GetComponent<Text>();
            CharacterName.text = "Caroline";
        }
        if (i == 1)
        {
            Text CharacterName = GameObject.Find("NotebookCanvas/Character Name").GetComponent<Text>();
            CharacterName.text = "The Heiress";
        }
        if (i == 2)
        {
            Text CharacterName = GameObject.Find("NotebookCanvas/Character Name").GetComponent<Text>();
            CharacterName.text = "James";
        }
        if (i == 3)
        {
            Text CharacterName = GameObject.Find("NotebookCanvas/Character Name").GetComponent<Text>();
            CharacterName.text = "Charles";
        }
        if (i == 4)
        {
            Text CharacterName = GameObject.Find("NotebookCanvas/Character Name").GetComponent<Text>();
            CharacterName.text = "The Failson";
        }
        if (i == 5)
        {
            Text CharacterName = GameObject.Find("NotebookCanvas/Character Name").GetComponent<Text>();
            CharacterName.text = "Yellow Journalist";
        }
        if (i == 6)
        {
            Text CharacterName = GameObject.Find("NotebookCanvas/Character Name").GetComponent<Text>();
            CharacterName.text = "War Bride";
        }
        if (i == 7)
        {
            Text CharacterName = GameObject.Find("NotebookCanvas/Character Name").GetComponent<Text>();
            CharacterName.text = "Thomas";
        }

     
    }
    
    /*
    public void Awake()
    {
        TextAsset xmlTextAsset = Resources.Load<TextAsset>("XML/Discriptions");

        personDataXml = new XmlDocument();
        personDataXml.LoadXml(xmlTextAsset.text);
    }
    */
    public void DiscriptionField()
    {
        XPathNavigator nav;
        XPathDocument docNav;
        XPathNodeIterator NodeIter;
        string strExpression;
        string path = "Assets\\Resources\\Discriptions.xml.txt";
        
        docNav = new XPathDocument(path);
        nav = docNav.CreateNavigator();

        // strExpression = ("/Suspects/Person");
        strExpression = ($"Suspects/Person[@Id='{i}']");
        NodeIter = nav.Select(strExpression);

        List<string> peopleArray = new List<string>();

        while (NodeIter.MoveNext())
         {
            peopleArray.Add(NodeIter.Current.Value);
         };

        Text Description = GameObject.Find("NotebookCanvas/Description Text").GetComponent<Text>();
        Description.text = NodeIter.Current.Value;
    }
    public void LoadHint1()
    {

        Text Hint1 = GameObject.Find("NotebookCanvas/Text Field 1").GetComponent<Text>();
        Hint1.text = "hinttest1";
    }
    public void LoadHint2()
    {

        Text Hint2 = GameObject.Find("NotebookCanvas/Text Field 2").GetComponent<Text>();
        Hint2.text = "hinttest2";
    }
    public void LoadHint3()
    {

        Text Hint3 = GameObject.Find("NotebookCanvas/Text Field 3").GetComponent<Text>();
        Hint3.text = "hinttest3";
    }
    public void LoadHint4()
    {

        Text Hint4 = GameObject.Find("NotebookCanvas/Text Field 4").GetComponent<Text>();
        Hint4.text = i.ToString();
    }
    public void UpdateImage()
    {
     //   Image CharacterHead = GameObject.Find("Canvas/Character Picture").GetComponent<Image>().sprite1;
     //   CharacterHead = "Assets\\Textures\\pepe.png";
    }
    public void ReloadPage()
    {
        CharacterName();
        DiscriptionField();
        LoadHint1();
        LoadHint2();
        LoadHint3();
        LoadHint4();
    }

    public void LoadXmlTree()
    {
        
    }

}
