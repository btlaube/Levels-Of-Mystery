using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public Slider SFXVolume;
    public Slider musicVolume;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake() {

        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start(){
        UpdateSFXVolume();
        UpdateMusicVolume();
        Play("MainTheme");
    }

    public void UpdateSFXVolume() {
        Sound s = Array.Find(sounds, sound => sound.name == "Click");
        if (s == null)
            Debug.Log("No such audio clip");
        s.source.volume = SFXVolume.value;
    }

    public void UpdateMusicVolume() {
        Sound s = Array.Find(sounds, sound => sound.name == "MainTheme");
        if (s == null)
            Debug.Log("No such audio clip");
        s.source.volume = musicVolume.value;
    }

    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            Debug.Log("No such audio clip");
        s.source.Play();
    }
    
}
