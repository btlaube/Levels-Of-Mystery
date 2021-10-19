using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public GameObject settings;

    public void Exit() {
        Application.Quit();
    }

    public void NewGame() {
        SceneManager.LoadScene(1);
    }

    //public void LoadSave() {
    //    
    //}

    public void ShowSettings() {
        settings.SetActive(true);
    }

    public void HideSettings() {
        settings.SetActive(false);
    }

}
