using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    float timer, milliSec, seconds, minutes;
    bool start;

    [SerializeField] Text stopWatchText;

    void Start()
    {
        start = false;
        timer = 0;
    }

    void Update()
    {
        stopWatchText = GameObject.Find("StopWatchText").GetComponent<Text>();
        StopWatchCalculation();
    }

    //Calculates time and applies it to the textfield
    void StopWatchCalculation(){
        if(start){
            timer += Time.deltaTime;
            milliSec = (int)((timer * 100) % 100);
            seconds = (int)(timer % 60);
            minutes = (int)((timer / 60) % 60);

            stopWatchText.text = minutes.ToString ("00") + ":" + seconds.ToString ("00") + ":" + milliSec.ToString ("00");
        }
    }

    //General functions to be called whenever needed
    public void StartTimer(){
        start = true;
    }
    public void PauseTimer(){
        start = false;
    }
    public void ResetTimer(){
        start = false;
        timer = 0;
    }
}
