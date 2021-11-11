using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //in seconds
    public float RemainingTime;
    bool paused = false;
    void Start()
    {
        RemainingTime = GameObject.Find("LevelManager").GetComponent<LevelManager>().starsTime[0];
        paused = false;
    }
    // Update is called once per frame
    void Update()
    {
        //if (GameObject.Find("LevelManager").GetComponent<LevelManager>().isPaused)
        {
            RemainingTime -= Time.deltaTime;
            if (RemainingTime >= 0f)
            {
                int minutes = Mathf.FloorToInt(RemainingTime / 60);
                int seconds = Mathf.FloorToInt(RemainingTime % 60);
                GetComponent<Text>().text = string.Format("{0:00}:{1:00}", minutes, seconds);
                paused = false;
            }
            else if(!paused)
            {//Run out of time 
                paused = true;
                GameObject.Find("LevelManager").GetComponent<LevelManager>().Lose();
            }
        }

    }
}
