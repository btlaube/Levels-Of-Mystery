using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGroupScript : MonoBehaviour
{
    public static CanvasGroupScript instance;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }
    
        DontDestroyOnLoad(gameObject);
    }

    public void ShowSettings() {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void HideSettings() {
        transform.GetChild(0).gameObject.SetActive(false);
    }

}
