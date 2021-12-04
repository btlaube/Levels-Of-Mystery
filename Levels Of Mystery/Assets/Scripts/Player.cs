using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int day = 1;
    public int time = 1;
    public Dictionary<string, List<string>> hints = new Dictionary<string, List<string>>();

    public static Player instance;

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

    #region UI Methods

    public void AddHint(string character, string hint) {
        this.hints[character].Add(hint);
    }

    public void UpdateDay() {
        day++;
        GameObject.Find("CanvasGroup").GetComponent<CanvasGroupScript>().EndOfDay();
        if ((day == 6 && time == 1) || (day == 11 && time == 1) || (day == 15 && time == 1)) {
            GameObject.Find("CanvasGroup").GetComponent<CanvasGroupScript>().Cutscene();
        }
    }

    public void UpdateTime() {
        if (time == 4){
            time = 1;
            UpdateDay();
        }
        else {
            time++;
        }
    }

    #endregion

    public void SavePlayer() {
        SaveSystem.SavePlayer(this);
        GameObject.Find("CanvasGroup").GetComponent<CanvasGroupScript>().GameSaved();
    }

    public void LoadPlayer() {
        PlayerData data = SaveSystem.LoadPlayer();
        day = data.day;
        time = data.time;
    }

}
