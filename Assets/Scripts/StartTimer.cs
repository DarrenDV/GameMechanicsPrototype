using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTimer : MonoBehaviour
{

    //This script is basically only used one
    //When the player passes te start collider this script makes the timer start.

    public Stopwatch stopwatch;
    public GameObject Player; 

    void Start()
    {
        stopwatch = GameObject.Find("GameManager").GetComponent<Stopwatch>();
        Player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject == Player){
            stopwatch.StartTimer();
        }
    }
}
