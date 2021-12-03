using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasGroupScript : MonoBehaviour
{
    string currentScene;
    public static CanvasGroupScript instance;
    //public Animator endOfDay;

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

    public void LoadMainMenu() {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);
        transform.GetChild(4).gameObject.SetActive(false);
    }

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

    public void EndOfDay() {
        transform.GetChild(5).gameObject.SetActive(true);
        //StartCoroutine(FadeOut());
    }

    public void GameSaved() {
        transform.GetChild(6).gameObject.SetActive(true);
    }

    //IEnumerator FadeOut() {
    //    yield return new WaitForSeconds(3);
    //    ShowNotebook();
    //    endOfDay.SetTrigger("Start");
    //}

}
