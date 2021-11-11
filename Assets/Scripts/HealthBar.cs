using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public Gradient gradient;

    float visibleTime = 1, elapsedTime = 1;
    float fadeOut = 0.5f;
    float alpha = 0;
    public void SetMaxValue(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    public void SetHealth(int health)
    {
        elapsedTime = 0;
        alpha = 1;
        slider.gameObject.SetActive(true);
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    private void Update()
    {
        if (slider.gameObject.activeSelf)
        {
            elapsedTime += Time.deltaTime;
            //calculating Fade out of the health bar if visibleTime is out
            if (elapsedTime >visibleTime)
            {
                if (elapsedTime < (visibleTime + fadeOut))
                {
                    alpha = 1 - (elapsedTime - visibleTime) * (1 / fadeOut);
                    fill.color = new Color(fill.color.r, fill.color.g, fill.color.b, alpha);
                }
                else
                {
                    slider.gameObject.SetActive(false);
                }
            }
        }
    }
}
