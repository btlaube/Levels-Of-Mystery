using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasGroupScript : MonoBehaviour
{
    string currentScene;
    public static CanvasGroupScript instance;

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

    public void Update() {
        currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Game") {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(3).gameObject.SetActive(true);
        }
        else if (currentScene == "MainMenu") {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    //public void LoadGameScene() {
    //    transform.GetChild(0).gameObject.SetActive(false);
    //    transform.GetChild(1).gameObject.SetActive(true);
    //}

    public void ShowSettings() {
        transform.GetChild(2).gameObject.SetActive(true);
    }

    public void HideSettings() {
        transform.GetChild(2).gameObject.SetActive(false);
    }

    public void ShowDialogue() {
        transform.GetChild(3).gameObject.SetActive(true);
    }

    public void HideDialogue() {
        transform.GetChild(3).gameObject.SetActive(false);
    }

    public void ShowNotebook() {
        transform.GetChild(4).gameObject.SetActive(true);
    }

    public void HideNotebook() {
        transform.GetChild(4).gameObject.SetActive(false);
    }

}
