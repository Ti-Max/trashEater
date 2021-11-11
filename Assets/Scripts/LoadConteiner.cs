using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadConteiner : MonoBehaviour
{
    public Text scorePanel;
    int containerInventory = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            containerInventory += collision.gameObject.GetComponent<ShipInventory>().inventoryStorage;

            //Ship starage
            collision.gameObject.GetComponent<ShipInventory>().inventoryStorage = 0;
            scorePanel.text = containerInventory.ToString();
            collision.gameObject.GetComponent<ShipInventory>().ShipEnventoryPanel.text = "0";

            //if all trash is solved
            if (containerInventory == GameObject.Find("LevelManager").GetComponent<LevelManager>().trashCount)
            {
                GameObject.Find("LevelManager").GetComponent<LevelManager>().Win();
            }
        }
    }
}
