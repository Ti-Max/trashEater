using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{

    private void Start()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        UpdateProgress();
    }
    public void UpdateProgress()
    {
        for (int i = 0; i < transform.childCount && i < GameManager.progress.Count; i++)
        {
            if (GameManager.progress[i].unlocked)
            {
                transform.GetChild(i).GetComponent<Button>().interactable = true;
                transform.GetChild(i).GetComponent<LevelButton>().lockImage.SetActive(false);
                if (GameManager.progress[i].bestTime > 0)
                {
                    transform.GetChild(i).GetComponent<LevelButton>().bestTimeText.GetComponent<Text>().text = "Best Time: " + string.Format("{00:00.00}",GameManager.progress[i].bestTime);
                }
                else
                {
                    transform.GetChild(i).GetComponent<LevelButton>().bestTimeText.GetComponent<Text>().text = "";
                }
                //stars
                if (GameManager.progress[i].stars > 1)
                {
                    transform.GetChild(i).GetComponent<LevelButton>().star1.GetComponent<Image>().color = Color.white;
                }
                else
                {
                    transform.GetChild(i).GetComponent<LevelButton>().star1.GetComponent<Image>().color = new Color(0, 0, 0, 1);
                }
                if (GameManager.progress[i].stars > 1)
                {
                    transform.GetChild(i).GetComponent<LevelButton>().star2.GetComponent<Image>().color = Color.white;
                }
                else
                {
                    transform.GetChild(i).GetComponent<LevelButton>().star2.GetComponent<Image>().color = new Color(0, 0, 0, 1);
                }
                if (GameManager.progress[i].stars == 3)
                {
                    transform.GetChild(i).GetComponent<LevelButton>().star3.GetComponent<Image>().color = Color.white;
                }
                else
                {
                    transform.GetChild(i).GetComponent<LevelButton>().star3.GetComponent<Image>().color = new Color(0, 0, 0, 1);
                }

            }
            else
            {
                transform.GetChild(i).GetComponent<Button>().interactable = false;
                transform.GetChild(i).GetComponent<LevelButton>().lockImage.SetActive(true);
                transform.GetChild(i).GetComponent<LevelButton>().bestTimeText.GetComponent<Text>().text = "";
                transform.GetChild(i).GetComponent<LevelButton>().star1.SetActive(false);
                transform.GetChild(i).GetComponent<LevelButton>().star2.SetActive(false);
                transform.GetChild(i).GetComponent<LevelButton>().star3.SetActive(false);
            }
        }
    }
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene("Level " + level);
    }
    public void LoadFirstLevel()
    {
        if (GameManager.progress[0].bestTime == 0f)
        {
            SceneManager.LoadScene("Start plot");
        }
        else
        {
            SceneManager.LoadScene("Level 1");

        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void SaveProgress()
    {
        GameManager.SaveProgress();
    }
    public void LoadProgress()
    {
        GameManager.loadProgress();
    }
}
