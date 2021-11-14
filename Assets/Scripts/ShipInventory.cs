using UnityEngine;
using UnityEngine.UI;

public class ShipInventory : MonoBehaviour
{
    public Text ShipEnventoryPanel;
    public int maxInventoryStorage = 5;
    public int inventoryStorage = 0;
    public GameObject InventoryFullMassage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trash"))
        {
            if (inventoryStorage < maxInventoryStorage)
            {
                inventoryStorage++;
                ShipEnventoryPanel.text = (inventoryStorage).ToString();
                Destroy(collision.gameObject);
            }
            else
            {
                //Storage is full
                if (!InventoryFullMassage.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FullInventoryMassage"))
                {
                    InventoryFullMassage.GetComponent<Animator>().SetTrigger("massage");
                }
            }
        }
    }
    
}
