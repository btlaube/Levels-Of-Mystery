using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int day = 1;
    public int time = 1;

    public static Player instance;

    #region UI Methods

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

    public void UpdateDay() {
        day++;
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
    }

    public void LoadPlayer() {
        PlayerData data = SaveSystem.LoadPlayer();
        day = data.day;
        time = data.time;
    }

}
