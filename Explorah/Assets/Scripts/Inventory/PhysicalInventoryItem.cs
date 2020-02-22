using UnityEngine;

public class PhysicalInventoryItem : MonoBehaviour
{
    [SerializeField] private Inventory playerInventory;
    [SerializeField] private InventoryItem thisItem;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !other.isTrigger);
        {
            AddItemToInventory();
            Destroy(this.gameObject);
        }
    }

    void AddItemToInventory()
    {
        if(playerInventory && thisItem)
        {
            playerInventory.AddItem(thisItem);
        }
    }
}
