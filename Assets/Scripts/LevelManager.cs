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
    public GameObject PauseMenu;
    public Timer Timer;
    public bool isPaused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();
                PauseMenu.SetActive(true);
            }
            else
            {
                Resume();
                PauseMenu.SetActive(false);
            }

        }
    }
    public void Lose()
    {
        GameOverPanel.SetActive(true);
        Pause();
    }
    public void Win()
    {
        WinningPanel.SetActive(true);
        Pause();
        //Counting stars
        float usedTime = starsTime[0] - Timer.RemainingTime;
        if (usedTime < starsTime[1])
        {
            WinningPanel.transform.Find("Star2").GetComponent<Image>().color = Color.white;
            if (usedTime < starsTime[2])
            {
                WinningPanel.transform.Find("Star3").GetComponent<Image>().color = Color.white;
            }
        }
    }
    public void LoadLevel(int level)
    {
        Resume();
        if (level > 0)
        {
            SceneManager.LoadScene(level - 1);
        }
    }
    public void LoadNextLevel()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ReLoadScene()
    {
        Debug.Log("reload");
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
    }
    private void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
    }
}
