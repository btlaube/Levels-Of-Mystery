using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int day = 1;
    public int time = 1;

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

    public void UpdateDay() {
        day++;
        GameObject.Find("CanvasGroup").GetComponent<CanvasGroupScript>().EndOfDay();
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
