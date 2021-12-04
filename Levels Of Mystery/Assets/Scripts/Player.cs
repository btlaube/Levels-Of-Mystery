using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int day = 1;
    public int time = 1;
    public Dictionary<string, List<string>> hints = new Dictionary<string, List<string>>();
    public int numAccuasations = 3;

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

    public int GetNumAccuasations() {
        return this.numAccuasations;
    }

    public void Accuse() {
        this.numAccuasations--;
    }

    public void ResetPlayer() {
        this.day = 1;
        this.time = 1;
        this.numAccuasations = 3;
    }

    public void AddHint(string character, string hint)
    {
        List<string> val;
        if (this.hints.TryGetValue(character, out val))
        {
            this.hints[character].Add(hint);
        }
        else
        {
            List<string> tempList = new List<string>(){hint};
            this.hints.Add(character, tempList);
        }
    }

    public void UpdateDay() {
        day++;
        if (this.day == 16) {
            GameObject.Find("CanvasGroup").GetComponent<CanvasGroupScript>().EndGame();
        }
        else {
            GameObject.Find("CanvasGroup").GetComponent<CanvasGroupScript>().EndOfDay();
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
        hints = data.hints;
        numAccuasations = data.numAccuasations;
    }

}
