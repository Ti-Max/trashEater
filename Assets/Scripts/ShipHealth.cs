using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipHealth : MonoBehaviour
{
    public Animator animator;
    public HealthBar healthBar;
    public GameObject inventoryText;
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
            GameObject.Find("LevelManager").GetComponent<LevelManager>().Lose("Trash eater wasn't made to ram things.");
            animator.updateMode = AnimatorUpdateMode.UnscaledTime;
            animator.SetTrigger("drawn");
            inventoryText.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
            inventoryText.GetComponent<Animator>().SetTrigger("drawn");
        }
        else
        {
            animator.SetTrigger("takeDamage");
        }
    }
}
