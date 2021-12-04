using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public Player player;

    public static LevelLoader instance;

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

    //public void LoadNextLevel() {
    //    StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    //}

    public void LoadGameScene() {
        StartCoroutine(LoadLevel(1));
    }

    public void LoadMainMenu() {
        StartCoroutine(LoadLevel(0));
    }

    public void NewGame() {
        player.ResetPlayer();
        
        StartCoroutine(LoadLevel(1));
    }

    public void ContinueGame() {
        StartCoroutine(LoadLevel(1));
    }

    IEnumerator LoadLevel(int levelIndex) {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
        if (levelIndex == 1) {
            if (player.day == 1 && player.time == 1){
                GameObject.Find("CanvasGroup").GetComponent<CanvasGroupScript>().NewGame();
            }
            else {
                GameObject.Find("CanvasGroup").GetComponent<CanvasGroupScript>().ContinueGame();
            }
            //GameObject.Find("CanvasGroup").GetComponent<CanvasGroupScript>().LoadGameScene();
        }
        else if (levelIndex == 0) {
            GameObject.Find("CanvasGroup").GetComponent<CanvasGroupScript>().LoadMainMenu();
        }
        transition.SetTrigger("End");
    }

    public void Quit() {
        Application.Quit();
    }

}
