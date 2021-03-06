using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasGroupScript : MonoBehaviour
{
    string currentScene;
    public static CanvasGroupScript instance;
    public Player player;
    public GameObject accuseButton;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }
    
        DontDestroyOnLoad(gameObject);
    }

    public void LoadGameScene() {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(3).gameObject.SetActive(true);
    }

    public void NewGame() {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(7).gameObject.SetActive(true);
    }

    public void ContinueGame() {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(3).gameObject.SetActive(true);
    }

    public void LoadMainMenu() {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);
        transform.GetChild(4).gameObject.SetActive(false);
        transform.GetChild(5).gameObject.SetActive(false);
        transform.GetChild(6).gameObject.SetActive(false);
        transform.GetChild(7).gameObject.SetActive(false);
        transform.GetChild(8).gameObject.SetActive(false);
        transform.GetChild(9).gameObject.SetActive(false);
        transform.GetChild(10).gameObject.SetActive(false);
    }

    public void ShowSettings() {
        transform.GetChild(2).gameObject.SetActive(true);
    }

    public void HideSettings() {
        transform.GetChild(2).gameObject.SetActive(false);
    }

    public void ShowNotebook() {
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);
        transform.GetChild(4).gameObject.SetActive(true);
    }

    public void HideNotebook() {
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(3).gameObject.SetActive(true);
        transform.GetChild(4).gameObject.SetActive(false);
    }

    public void EndOfDay() {
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);
        transform.GetChild(5).gameObject.SetActive(true);
    }

    public void GameSaved() {
        transform.GetChild(6).gameObject.SetActive(true);
    }

    public void Cutscene() {
        transform.GetChild(7).gameObject.SetActive(true);
    }

    public void ShowAccuasationButton() {
        accuseButton.SetActive(true);
    }

    public void ShowAccuasation() {
        transform.GetChild(8).gameObject.SetActive(true);
    }

    public void HideAccuasation() {
        transform.GetChild(8).gameObject.SetActive(false);
    }

    public void EndGame() {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);
        transform.GetChild(4).gameObject.SetActive(false);
        transform.GetChild(5).gameObject.SetActive(false);
        transform.GetChild(6).gameObject.SetActive(false);
        transform.GetChild(7).gameObject.SetActive(false);
        transform.GetChild(8).gameObject.SetActive(false);
        transform.GetChild(9).gameObject.SetActive(false);
        transform.GetChild(10).gameObject.SetActive(true);
        transform.GetChild(10).gameObject.GetComponent<LoseScript>().ShowText(1);
    }

}
