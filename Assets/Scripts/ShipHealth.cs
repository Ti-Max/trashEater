using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipHealth : MonoBehaviour
{
    public HealthBar healthBar;
    public int health = 10000;
    private void Start()
    {
        healthBar.SetMaxValue(health);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        if (health <= 0)
        {
            GameObject.Find("LevelManager").GetComponent<LevelManager>().Lose();
        }
    }
}
