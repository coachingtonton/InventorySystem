using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private BoxCollider2D BoxCollider2D;
    [SerializeField] ItemDataSO itemData;
    [SerializeField] private int pickupQuantity = 1;
     
    private void Awake()
    {
        BoxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)     
    {
        if (other.GetComponent<InventoryManager>() != null)
        {
            EventManager.current.TriggerItemPickedUp(itemData, pickupQuantity);
            Destroy(gameObject);// DESTROYS POTION GAMEOBJECT
        }
    }
}
