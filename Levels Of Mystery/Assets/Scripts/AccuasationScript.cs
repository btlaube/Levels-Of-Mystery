using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccuasationScript : MonoBehaviour
{
    public int numAccuasations = 3;
    public Text accuasationText;
    public GameObject virginiaButton;
    public GameObject alexButton;
    public GameObject jamesButton;
    public GameObject carolineButton;
    public GameObject lucyButton;
    public GameObject thomasButton;

    public GameObject alexX;
    public GameObject jamesX;
    public GameObject carolineX;
    public GameObject lucyX;
    public GameObject thomasX;

    void Start() {
        accuasationText.text = "Accuasations Left: " + numAccuasations.ToString() + "/3";
    }

    public void Accuse(string accused) {
        numAccuasations--;
        accuasationText.text = "Accuasations Left: " + numAccuasations.ToString() + "/3";
        if (accused == "Virginia") {
            //win
        }
        else if (accused == "Alex"){
            alexX.SetActive(true);
            alexButton.GetComponent<Button>().interactable = false;
        }
        else if (accused == "Caroline"){
            carolineX.SetActive(true);
            carolineButton.GetComponent<Button>().interactable = false;
        }
        else if (accused == "James"){
            jamesX.SetActive(true);
            jamesButton.GetComponent<Button>().interactable = false;
        }
        else if (accused == "Thomas"){
            thomasX.SetActive(true);
            thomasButton.GetComponent<Button>().interactable = false;
        }
        else if (accused == "Lucy"){
            lucyX.SetActive(true);
            lucyButton.GetComponent<Button>().interactable = false;
        }
    }

    void Update() {
        if (numAccuasations == 0) {
            //lose
        }
    }

}
