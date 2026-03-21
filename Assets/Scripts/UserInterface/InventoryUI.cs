using System.Linq;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    /// <summary>
    /// TODO 
    /// Figure out if opening inventory results in time slow or stop 
    /// if time doesent stop implement system for keeping items in inventory updated a you 
    /// </summary>


    // Checks if menu is toggled on 
    private bool menuActivated;

    // Refrences
    public GameObject InventoryMenu;
    [SerializeField] public InputCHECKERFUCK inputChecker;
    public InventoryManager inventoryManager;

    // Inventory slot array
    InventorySlots[] slots;


    private void Start()
    {
        inventoryManager = FindAnyObjectByType<InventoryManager>();
        InventoryMenu.SetActive(false);
        inventoryManager.inventory.OnInventoryChanged += RefreshUI;     

        //Gets all inventorySlotScripts inchildren and stores them in slots array
        slots = GetComponentsInChildren<InventorySlots>(true);
    }

    private void Update()
    {

        if (inputChecker.iKeyPressed && menuActivated)
        {
            // deactivates Menu
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }
        else if (inputChecker.iKeyPressed && !menuActivated)
        {
            //Activates menu and refreshes inventory
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }
    }

    public void RefreshUI()
    {
        //Compares slots index to list of inventory items
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].slotIndex = i;

            // Compares array of slots to inventory list if inventory 
            // list has higher count than slots array, slots will run
            // Update slot method and store new inventory item
            if (i < inventoryManager.inventory.currentInventoryItems.Count
    && inventoryManager.inventory.currentInventoryItems[i] != null)
            {
                slots[i].UpdateSlot(inventoryManager.inventory.currentInventoryItems[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
