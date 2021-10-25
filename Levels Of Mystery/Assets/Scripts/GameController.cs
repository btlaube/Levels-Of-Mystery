using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject settings;

    //public static GameController instance;

    //void Awake() {
    //    if (instance == null) {
    //        instance = this;
    //    }
    //    else {
    //        Destroy(gameObject);
    //        return;
    //    }
    //
    //    DontDestroyOnLoad(gameObject);
    //}

    public void ShowSettings() {
        settings.SetActive(true);
    }

    public void HideSettings() {
        settings.SetActive(false);
    }
}
