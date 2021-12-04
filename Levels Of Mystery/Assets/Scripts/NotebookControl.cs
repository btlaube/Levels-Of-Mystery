using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Xml;
using System.Xml.XPath;
using System;
using System.IO;


public class NotebookControl : MonoBehaviour
{
    public Image NotebookImage;

    private int i = 0;

    public Player player;

    public Text Description;

    public XmlDocument personDataXml;

    public void LoadNotebook()
    {
        ReloadPage();
    }
    public void ButtonExit()
    {
        SceneManager.LoadScene(1);
    }
    public void ButtonNext()
    {
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
        DiscriptionField();
        if (i == 0)
        {
            Text CharacterName = GameObject.Find("NotebookCanvas/Character Name").GetComponent<Text>();
            CharacterName.text = "Caroline";

            NotebookImage.sprite = Resources.Load<Sprite>("CharacterSprites\\Caroline");
           /* if(player.hints["Caroline"] != null)
            {
                int a = 0;
                foreach (string hint in player.hints["Caroline"])
                {
                    Text HintSpot = GameObject.Find("NotebookCanvas/Text Field " + a + "").GetComponent<Text>();
                    HintSpot.text = hint;
                    a++;
                }
            }*/
          
        }
        if (i == 1)
        {
            Text CharacterName = GameObject.Find("NotebookCanvas/Character Name").GetComponent<Text>();
            CharacterName.text = "Virginia";

            NotebookImage.sprite = Resources.Load<Sprite>("CharacterSprites\\Virginia");
/*
            if (player.hints["Caroline"] == 17)
            {
                int a = 0;
                foreach (string hint in player.hints["Virginia"])
                {
                    Text HintSpot = GameObject.Find("NotebookCanvas/Text Field " + a + "").GetComponent<Text>();
                    HintSpot.text = hint;
                    a++;
                }
            }*/
        }
        if (i == 2)
        {
            Text CharacterName = GameObject.Find("NotebookCanvas/Character Name").GetComponent<Text>();
            CharacterName.text = "James";

            NotebookImage.sprite = Resources.Load<Sprite>("CharacterSprites\\James");

         /*   if (player.hints["Caroline"] == 17)
            {
                int a = 0;
                foreach (string hint in player.hints["James"])
                {
                    Text HintSpot = GameObject.Find("NotebookCanvas/Text Field " + a + "").GetComponent<Text>();
                    HintSpot.text = hint;
                    a++;
                }
            }*/
        }
        if (i == 3)
        {
            Text CharacterName = GameObject.Find("NotebookCanvas/Character Name").GetComponent<Text>();
            CharacterName.text = "Charles";

            NotebookImage.sprite = Resources.Load<Sprite>("CharacterSprites\\Charles");

          /*  if (player.hints["Caroline"] == 17)
            {
                int a = 0;
                foreach (string hint in player.hints["Charles"])
                {
                    Text HintSpot = GameObject.Find("NotebookCanvas/Text Field " + a + "").GetComponent<Text>();
                    HintSpot.text = hint;
                    a++;
                }
            }*/
        }
        if (i == 4)
        {
            Text CharacterName = GameObject.Find("NotebookCanvas/Character Name").GetComponent<Text>();
            CharacterName.text = "Alex";

            NotebookImage.sprite = Resources.Load<Sprite>("CharacterSprites\\AlexTemp");

           /* if (player.hints["Caroline"] == 17)
            {
                int a = 0;
                foreach (string hint in player.hints["Alex"])
                {
                    Text HintSpot = GameObject.Find("NotebookCanvas/Text Field " + a + "").GetComponent<Text>();
                    HintSpot.text = hint;
                    a++;
                }
            }*/
        }
        if (i == 5)
        {
            Text CharacterName = GameObject.Find("NotebookCanvas/Character Name").GetComponent<Text>();
            CharacterName.text = "Lucy";

            NotebookImage.sprite = Resources.Load<Sprite>("CharacterSprites\\Lucy");

         /*   if (player.hints["Caroline"] == 17)
            {
                int a = 0;
                foreach (string hint in player.hints["lucy"])
                {
                    Text HintSpot = GameObject.Find("NotebookCanvas/Text Field " + a + "").GetComponent<Text>();
                    HintSpot.text = hint;
                    a++;
                }
            }*/
        }
        if (i == 6)
        {
            Text CharacterName = GameObject.Find("NotebookCanvas/Character Name").GetComponent<Text>();
            CharacterName.text = "Thomas";

            NotebookImage.sprite = Resources.Load<Sprite>("CharacterSprites\\BillMurray");

           /* if (player.hints["Caroline"] == 17)
            {
                int a = 0;
                foreach (string hint in player.hints["Thomas"])
                {
                    Text HintSpot = GameObject.Find("NotebookCanvas/Text Field " + a + "").GetComponent<Text>();
                    HintSpot.text = hint;
                    a++;
                }
            }*/
        }


    }

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

        Description.text = NodeIter.Current.Value;
    }
    public void ReloadPage()
    {
        DiscriptionField();
        CharacterName();
    }


}