using UnityEngine;
using UnityEngine.UI;

public class SaveTestScript : MonoBehaviour
{
    public Text day;
    public Text time;
    public Player player;

    public void Update() {
        day.text = "Day: " + player.day.ToString();
        if (player.time == 1) {
            time.text = "Time: Morning";
        }
        else if (player.time == 2) {
            time.text = "Time: Afternoon";
        }
        else if (player.time == 3) {
            time.text = "Time: Evening";
        }
        else if (player.time == 4) {
            time.text = "Time: Night";
        }
    }

}
