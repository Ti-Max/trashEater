using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public Timer timer;
    public GameObject Star3;
    public GameObject Star2;

    private bool lostStar3 = false;
    private bool lostStar2 = false;
    private void Start()
    {
        SetMaxValue(LevelManager.starsTime[0]);
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

        if (!lostStar3 && timer.RemainingTime < LevelManager.starsTime[1])
        {
            Star3.SetActive(false);
            lostStar3 = true;
        }
        if (!lostStar2 && timer.RemainingTime < LevelManager.starsTime[2])
        {
            Star2.SetActive(false);
            lostStar2 = true;
        }
    }
}
