using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    //in seconds
    LevelManager levelManager;
    public Animator animator;
    public float RemainingTime;
    bool paused = false;
    void Start()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        RemainingTime = levelManager.InputStarsTime[0];
        paused = false;
    }
    // Update is called once per frame
    void Update()
    {
        RemainingTime -= Time.deltaTime;
        if (RemainingTime >= 0f)
        {
            string timeString;
            //9.95 here because string.Format rounds RemainingTime. 
            if (RemainingTime < 9.95f)
            {
                timeString =  string.Format("{0:0.0}", RemainingTime);
                animator.SetBool("timerImpuls", true);
            }
            else
            {
                timeString = string.Format("{0:0}", RemainingTime);
            }
            GetComponent<Text>().text = timeString;
            paused = false;
        }
        else if(!paused)
        {//Run out of time 
            paused = true;
            GameObject.Find("LevelManager").GetComponent<LevelManager>().Lose("You have to be faster, trash wont wait.");
        }

    }
}
