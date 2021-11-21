using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorSound : MonoBehaviour
{
    private void PlayElevatorSound() {

        GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("ElevatorOpen");
    }

    private void StopElevatorSound() {

        GameObject.Find("AudioManager").GetComponent<AudioManager>().Stop("ElevatorOpen");
    }

}
