using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
    public Toggle music;
    public Slider volume;

    public void Awake()
    {
        initializeMusic();
        initializeVolume();
    }


    private void initializeMusic() {
        if (!PlayerPrefs.HasKey("music")) {
            PlayerPrefs.SetInt("music", 1);
            music.isOn = true;
            PlayerPrefs.Save();
        }
        else {
            if (PlayerPrefs.GetInt("music") == 0)
            {
                music.isOn = false;
            }
            else
            {
                music.isOn = true;
            }
        }
    }

    public void initializeVolume() {
        if (!PlayerPrefs.HasKey("volume")) {
            PlayerPrefs.SetInt("volume", 100);
            volume.value = 100;
            PlayerPrefs.Save();
        }
        else {
            volume.value = PlayerPrefs.GetInt("volume");
        }
    }

    public void updateMusic() {
        if (music.isOn)
        {
            PlayerPrefs.SetInt("music", 1);
        }
        else
        {
            PlayerPrefs.SetInt("music", 0);
        }
        PlayerPrefs.Save();
    }

    public void updateVolume() {
        PlayerPrefs.SetInt("volume", (int)(volume.value));
    }

    public void Reset() {
        PlayerPrefs.DeleteKey("music");
        music.isOn = true;

        PlayerPrefs.DeleteKey("volume");
        volume.value = 100;
    }

}
