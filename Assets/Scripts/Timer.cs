using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //in seconds
    public float RemainingTime;
    public bool timerIsRunning = true;

    void Start()
    {
        RemainingTime = GameObject.Find("LevelManager").GetComponent<LevelManager>().starsTime[0];
    }
    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning && GameObject.FindGameObjectWithTag("Player"))
        {
            RemainingTime -= Time.deltaTime;
            if (RemainingTime > 0)
            {
                int minutes = Mathf.FloorToInt(RemainingTime / 60);
                int seconds = Mathf.FloorToInt(RemainingTime % 60);
                GetComponent<Text>().text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else
            {//Run out of time 
                GameObject.Find("LevelManager").GetComponent<LevelManager>().Lose();
                timerIsRunning = false;
            }
        }

    }
}
