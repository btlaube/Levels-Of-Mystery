using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndDayScript : MonoBehaviour
{
    public Text day;
    public Text time;
    public Player player;

    public void Start() {
        day.text = "Day " + (player.day - 1).ToString() + " completed.";
    }

    public void UpdateDay() {
        Debug.Log(player.day);
        day.text = "Beginning day " + player.day.ToString() + "...";
    }

    public void HideSelf() {
        gameObject.SetActive(false);
    }

}
