using UnityEngine;

public class PotionObject : MonoBehaviour
{
    private BoxCollider2D BoxCollider2D;
    private InventoryManager inventoryTester;
    [SerializeField] ItemDataSO potionSO;
    private int pickupQuantity = 1;
     
    private void Awake()
    {
        BoxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)     
    {
        inventoryTester = other.GetComponent<InventoryManager>(); // GETS INVENTORY MANAGER OFF PLAYER
        if (inventoryTester != null)
        {
            inventoryTester.PickupItem(pickupQuantity, potionSO);// RUNS PICKUP METHOD, ADDS ITEM TO INVENTORY 
            Destroy(gameObject);// DESTROYS POTION GAMEOBJECT
        }
    }
}
