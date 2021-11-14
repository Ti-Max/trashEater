using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void Donate()
    {
        Application.OpenURL("https://teamseas.org/");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public  void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }
}
