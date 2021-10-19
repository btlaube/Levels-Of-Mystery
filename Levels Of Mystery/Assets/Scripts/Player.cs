using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int day = 1;
    public int time = 1;

    #region UI Methods

    public void UpdateDay() {
        day++;
    }

    public void UpdateTime() {
        if (time == 4){
            time = 1;
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
