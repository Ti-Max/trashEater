using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Plot : MonoBehaviour
{
    public GameObject PauseMenu;
    public float timeBeforePlot = 10f;
    public float timeBeforeSmoke = 2f;
    public GameObject massage;
    public GameObject introductionMassage;
    public GameObject introductionMassage2;
    public static bool plotStarted = false;
    float timer = 0;
    //massages
    string[] massages = 
        {"The Interceptor is broken!!!",
        "Now trash will get to the ocean!!",
         "All these little fish. They....",
         "they can die.....",
         "Help us clear the river of garbage." };
    int activeMassage = 0;

    bool smokeStarted = false;
    bool isPaused = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !plotStarted)
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (!plotStarted)
        {
            timer += Time.deltaTime;
            if (timer > timeBeforePlot)
            {
                StartPlot();
            }
            else if (timer > timeBeforeSmoke && !smokeStarted)
            {
                smokeStarted = true;
                GetComponentInChildren<ParticleSystem>().Play();
            }
        }
    }
    public void Pause()
    {
        PauseMenu.SetActive(true);

        isPaused = true;
        Time.timeScale = 0f;
    }
    public void Resume()
    {
                PauseMenu.SetActive(false);

        isPaused = false;
        Time.timeScale = 1f;
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    void StartPlot()
    {
        plotStarted = true;
        massage.SetActive(true);
        massage.transform.GetChild(0).gameObject.GetComponent<Text>().text = massages[0];
        Time.timeScale = 0f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trash") && !plotStarted)
        {
            Destroy(collision.gameObject);
        }
    }
    public void NextMessage()
    {
        activeMassage++;
        if (activeMassage < massages.Length )
        {
            massage.transform.GetChild(0).gameObject.GetComponent<Text>().text = massages[activeMassage];
        }
        else if (activeMassage == massages.Length)
        {
            introductionMassage.SetActive(true);
            massage.SetActive(false);
        }
        else if (activeMassage == massages.Length + 1)
        {
            GameObject.Find("IntroductionText").GetComponent<Text>().text = "He can eat 5 pieces of garbage at a time";
            GameObject.Find("IntroductionText").transform.GetChild(0).GetComponent<Text>().text = "5";

        }
        else if (activeMassage == massages.Length + 2)
        {
            introductionMassage.SetActive(false);
            introductionMassage2.SetActive(true);
        }
        else if (activeMassage == massages.Length + 3)
        {
            GameObject.Find("IntroductionText").GetComponent<Text>().text = "Then do it again until the river is clear";
        }
        else//massages done
        {
            GameManager.progress[1].unlocked = true;
            SceneManager.LoadScene("Level 1");
            Time.timeScale = 1f;
        }
    }
}
