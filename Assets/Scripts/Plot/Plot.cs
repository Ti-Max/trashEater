using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Plot : MonoBehaviour
{
    public float timeBeforePlot = 10f;
    public GameObject massage;
    public static bool plotStarted = false;
    float timer = 0;
    //massages
    string[] massages = 
        {"The Interceptor is broken!!!",
         "Help us clear the river of garbage." };
    int activeMassage = 0;
    // Update is called once per frame
    void Update()
    {
        if (!plotStarted)
        {
            timer += Time.deltaTime;
            if (timer > timeBeforePlot)
            {
                StartPlot();
            }
        }
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
        else//massages done
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Level 1");
        }
    }
}
