using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
    public Toggle music;
    public Slider volume;

    private int defaultVolume = 100;
    private bool defaultMusic = true;

    public void Awake()
    {
        initializeMusic();
        initializeVolume();
    }

    public void initializeMusic() {
        if (!PlayerPrefs.HasKey("music")) {
            PlayerPrefs.SetInt("music", 1);
            music.isOn = defaultMusic;
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
            PlayerPrefs.SetInt("volume", defaultVolume);
            volume.value = defaultVolume;
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
        volume.value = defaultVolume;
    }

}
