using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    LevelManager levelManager;
    public Slider slider;
    public Image fill;
    public Timer timer;
    public GameObject Star3;
    public GameObject Star2;

    private bool lostStar3 = false;
    private bool lostStar2 = false;
    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        SetMaxValue(levelManager.InputStarsTime[0]);
    }
    public void SetMaxValue(float value)
    {
        slider.maxValue = value;
        slider.value = value;
    }
    public void SetValue(float value)
    {
        slider.value = value;
    }

    private void Update()
    {
        SetValue(timer.RemainingTime);

        if (!lostStar3 && timer.RemainingTime < levelManager.InputStarsTime[1])
        {
            Star3.SetActive(false);
            lostStar3 = true;
        }
        if (!lostStar2 && timer.RemainingTime < levelManager.InputStarsTime[2])
        {
            Star2.SetActive(false);
            lostStar2 = true;
        }
    }
}
