using UnityEngine;
using UnityEngine.UI;

public class NewPlayerSettings : MonoBehaviour
{
    public Slider musicVolume;
    public Slider SFXVolume;

    private int defaultSFXVolume = 1;
    private int defaultMusicVolume = 1;

    public AudioManager audioManager;

    public void Start()
    {
        initializeMusicVolume();
        initializeSFXVolume();        
    }

    public void initializeMusicVolume() {
        if (!PlayerPrefs.HasKey("musicVolume")) {
            PlayerPrefs.SetFloat("musicVolume", defaultMusicVolume);
            musicVolume.value = defaultMusicVolume;
            PlayerPrefs.Save();
        }
        else {
            musicVolume.value = PlayerPrefs.GetFloat("musicVolume");
        }
    }

    public void initializeSFXVolume() {
        if (!PlayerPrefs.HasKey("SFXVolume")) {
            PlayerPrefs.SetFloat("SFXVolume", defaultSFXVolume);
            SFXVolume.value = defaultSFXVolume;
            PlayerPrefs.Save();
        }
        else {
            SFXVolume.value = PlayerPrefs.GetFloat("SFXVolume");
        }
    }

    public void updateMusicVolume() {
        PlayerPrefs.SetFloat("musicVolume", (float)(musicVolume.value));
    }

    public void updateSFXVolume() {
        PlayerPrefs.SetFloat("SFXVolume", (float)(SFXVolume.value));
    }

    //public void Reset() {
    //    PlayerPrefs.DeleteKey("music");
    //    music.isOn = true;
    //
    //    PlayerPrefs.DeleteKey("volume");
    //    volume.value = defaultVolume;
    //}

}
