using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadConteiner : MonoBehaviour
{
    public Text scorePanel;
    int containerInventory = 0;
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.8f);
            containerInventory += collision.gameObject.GetComponent<ShipInventory>().inventoryStorage;
            //Conteiner animation
            if (collision.gameObject.GetComponent<ShipInventory>().inventoryStorage > 0)
            {
                LoadAnimation();
            }

            //Ship storage
            collision.gameObject.GetComponent<ShipInventory>().inventoryStorage = 0;
            scorePanel.text = containerInventory.ToString();
            collision.gameObject.GetComponent<ShipInventory>().ShipEnventoryPanel.text = "0";
            //if all trash is solved
            if (containerInventory >= GameObject.Find("LevelManager").GetComponent<LevelManager>().trashCount)
            {
                GameObject.Find("LevelManager").GetComponent<LevelManager>().Win();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        }
    }
    private void LoadAnimation()
    {
        animator.SetTrigger("load");
    }
}
