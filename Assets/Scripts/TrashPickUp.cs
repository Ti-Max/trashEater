using UnityEngine;
using UnityEngine.UI;

public class TrashPickUp : MonoBehaviour
{
    public Text scorePanel;
    static private int score = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            scorePanel.text = (++score).ToString();
            Destroy(gameObject);
        }
    }
}
