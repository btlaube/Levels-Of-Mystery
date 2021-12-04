using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndDayScript : MonoBehaviour
{
    public Text day;
    public Player player;

    public void OnEnable() {
        day.text = "Day " + (player.day - 1).ToString() + " completed.";
    }

    public void UpdateDay() {
        day.text = "Beginning day " + player.day.ToString() + "...";
        GameObject.Find("CanvasGroup").GetComponent<CanvasGroupScript>().ShowNotebook();
        GameObject.Find("CanvasGroup").GetComponent<NotebookControl>().LoadNotebook();
        if (player.day == 6) {
            GameObject.Find("CanvasGroup").GetComponent<CanvasGroupScript>().ShowAccuasation();
            GameObject.Find("CanvasGroup").GetComponent<CanvasGroupScript>().ShowAccuasationButton();
        }
        if ((player.day == 6 && player.time == 1) || (player.day == 11 && player.time == 1)) {
            GameObject.Find("CanvasGroup").GetComponent<CanvasGroupScript>().Cutscene();
        }
    }

    public void HideSelf() {
        gameObject.SetActive(false);
    }

}
