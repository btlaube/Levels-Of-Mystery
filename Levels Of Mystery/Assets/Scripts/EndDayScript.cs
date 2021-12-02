using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndDayScript : MonoBehaviour
{
    public Text day;
    public Text time;
    public Player player;

    public void UpdateDay() {
        Debug.Log(player.day);
        day.text = "Day: " + player.day.ToString();
    }
}
