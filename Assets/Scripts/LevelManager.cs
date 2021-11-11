using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //How much trash you need to collect to finish the level. ex. {30:00, 25:00, 20:00}
    public float[] starsTime = new float[3];
    public int trashCount = 1;

    public GameObject GameOverPanel;
    public GameObject WinningPanel;
    public Timer Timer;
    
    public void Lose()
    {
        GameOverPanel.SetActive(true);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }
    public void Win()
    {
        WinningPanel.SetActive(true);

        //Counting stars
        Timer.timerIsRunning = false;
        float usedTime = starsTime[0] - Timer.RemainingTime;
        if (usedTime < starsTime[1])
        {
            WinningPanel.transform.Find("Star2").GetComponent<Image>().color = Color.white;
            if (usedTime < starsTime[2])
            {
                WinningPanel.transform.Find("Star3").GetComponent<Image>().color = Color.white;
            }
        }
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }
    public void LoadLevel(int level)
    {
        if (level > 0)
        {
            SceneManager.LoadScene(level - 1);
        }
    }
}
