using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //How much trash you need to collect to finish the level. ex. {30:00, 25:00, 20:00}
    public float[] InputStarsTime = new float[3];
    public int LevelId;
    public int trashCount = 1;

    public GameObject GameOverPanel;
    public GameObject DeathMassage;
    public GameObject WinningPanel;
    public GameObject PauseMenu;
    public Timer Timer;
    public bool isPaused;
    bool gameOver = false;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && !gameOver)
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
    public void Lose(string deathMassage)
    {
        gameOver = true;
        GameOverPanel.SetActive(true);
        DeathMassage.GetComponent<Text>().text = deathMassage;
        Pause();
    }
    public void Win()
    {
        gameOver = true;
        WinningPanel.SetActive(true);
        Pause();
        //Counting stars
        float usedTime = InputStarsTime[0] - Timer.RemainingTime;
        int stars = 1;
        if (Timer.RemainingTime > InputStarsTime[2])
        {
            stars++;
            WinningPanel.transform.Find("Star2").GetComponent<Image>().color = Color.white;
            if (Timer.RemainingTime > InputStarsTime[1])
            {
                stars++;
                WinningPanel.transform.Find("Star3").GetComponent<Image>().color = Color.white;
            }
        }
        //safe Progress
        if (GameManager.progress[LevelId].bestTime > usedTime || GameManager.progress[LevelId].bestTime == 0f)
        {
            GameManager.progress[LevelId].bestTime = usedTime;
            GameManager.progress[LevelId].stars = stars;
            if (LevelId != 10)
            {
                GameManager.progress[LevelId+1].unlocked = true;
            }
            GameManager.SaveProgress();
        }
        else
        {
            Debug.Log("Not the best score!!");
        }
    }
    public void LoadLevel(int level)
    {
        Resume();
        SceneManager.LoadScene(level);
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Resume();
    }
    public void ReLoadScene()
    {
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
