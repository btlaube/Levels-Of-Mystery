using UnityEngine;
using UnityEngine.UI;

public class NewPlayerSettings : MonoBehaviour
{
    public Slider musicVolume;
    public Slider SFXVolume;

    private int defaultSFXVolume = 1;
    private int defaultMusicVolume = 1;

    public void Awake()
    {
        initializeMusicVolume();
        initializeSFXVolume();
    }

    public void initializeMusicVolume() {
        if (!PlayerPrefs.HasKey("musicVolume")) {
            PlayerPrefs.SetInt("musicVolume", defaultMusicVolume);
            musicVolume.value = defaultMusicVolume;
            PlayerPrefs.Save();
        }
        else {
            SFXVolume.value = PlayerPrefs.GetInt("musicVolume");
        }
    }

    public void initializeSFXVolume() {
        if (!PlayerPrefs.HasKey("SFXVolume")) {
            PlayerPrefs.SetInt("SFXVolume", defaultSFXVolume);
            SFXVolume.value = defaultSFXVolume;
            PlayerPrefs.Save();
        }
        else {
            SFXVolume.value = PlayerPrefs.GetInt("SFXVolume");
        }
    }

    public void updateMusicVolume() {
        PlayerPrefs.SetInt("musicVolume", (int)(musicVolume.value));
    }

    public void updateSFXVolume() {
        PlayerPrefs.SetInt("SFXVolume", (int)(SFXVolume.value));
    }

    //public void Reset() {
    //    PlayerPrefs.DeleteKey("music");
    //    music.isOn = true;
    //
    //    PlayerPrefs.DeleteKey("volume");
    //    volume.value = defaultVolume;
    //}

}
