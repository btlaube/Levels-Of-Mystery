using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Xml;
using System.Xml.XPath;


public class NotebookControl : MonoBehaviour
{
    public Text Hint1 = GameObject.Find("NotebookCanvas/Text Field 1").GetComponent<Text>();
    public Text Hint2 = GameObject.Find("NotebookCanvas/Text Field 2").GetComponent<Text>();
    public Text Hint3 = GameObject.Find("NotebookCanvas/Text Field 3").GetComponent<Text>();
    public Text Hint4 = GameObject.Find("NotebookCanvas/Text Field 4").GetComponent<Text>();
    private int i = 0;

    public XmlDocument personDataXml;

    public void ButtonExit()
    {
        SceneManager.LoadScene(1);
    }
    public void ButtonNext()
    {
        Text Hint1 = GameObject.Find("NotebookCanvas/Text Field 1").GetComponent<Text>();
        if (i != 6)
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
            Hint1.text = hints <"Caroline"><1>;
            Hint2.text = hints < "Caroline" >< 1 >;
            Hint3.text = hints < "Caroline" >< 1 >;
            Hint4.text = hints < "Caroline" >< 1 >;
        }
        if (i == 1)
        {
            Text CharacterName = GameObject.Find("NotebookCanvas/Character Name").GetComponent<Text>();
            CharacterName.text = "The Heiress";
            Hint1.text = hints<"The Heiress"><1>;
            Hint2.text = hints < "The Heiress" >< 1 >;
            Hint3.text = hints < "The Heiress" >< 1 >;
            Hint4.text = hints < "The Heiress" >< 1 >;
        }
        if (i == 2)
        {
            Text CharacterName = GameObject.Find("NotebookCanvas/Character Name").GetComponent<Text>();
            CharacterName.text = "James";
            Hint1.text = hints <"James"><1>;
            Hint2.text = "";
            Hint3.text = "";
            Hint4.text = "";
        }
        if (i == 3)
        {
            Text CharacterName = GameObject.Find("NotebookCanvas/Character Name").GetComponent<Text>();
            CharacterName.text = "Charles";
            Hint1.text = hints <"Charles"><1>;
            Hint2.text = "";
            Hint3.text = "";
            Hint4.text = "";
        }
        if (i == 4)
        {
            Text CharacterName = GameObject.Find("NotebookCanvas/Character Name").GetComponent<Text>();
            CharacterName.text = "Yellow Journalist";
            Hint1.text = hints <"Yellow Journalist"><1>;
            Hint2.text = "";
            Hint3.text = "";
            Hint4.text = "";
        }
        if (i == 5)
        {
            Text CharacterName = GameObject.Find("NotebookCanvas/Character Name").GetComponent<Text>();
            CharacterName.text = hints <"War Bride"><1>;
            Hint1.text = "";
            Hint2.text = "";
            Hint3.text = "";
            Hint4.text = "";
        }
        if (i == 6)
        {
            Text CharacterName = GameObject.Find("NotebookCanvas/Character Name").GetComponent<Text>();
            CharacterName.text = hints <"Thomas"><1>;
            Hint1.text = "";
            Hint2.text = "";
            Hint3.text = "";
            Hint4.text = "";
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
    public void UpdateImage()
    {
       // image.sprite = Resources.Load<Sprite>(Tree.CharacterPNGPath);
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
