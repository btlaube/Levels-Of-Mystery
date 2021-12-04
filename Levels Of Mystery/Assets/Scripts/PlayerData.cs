using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int day;
    public int time;
    public Dictionary<string, List<string>> hints;
    public int numAccuasations;

    public PlayerData (Player player) {
        day = player.day;
        time = player.time;
        hints = player.hints;
        numAccuasations = player.numAccuasations;
    }

}
