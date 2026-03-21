using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventorySlots : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Image itemIcon;
    public TextMeshProUGUI quantityText;
    private Item currentItem;
    [SerializeField] ItemInfoPanel itemInfoPanel;

    // Drag and drop
    public int slotIndex;          // Set by InventoryUI during RefreshUI
    private GameObject dragIcon;   // The floating image that follows your mouse
    private Canvas canvas;
    private InventoryUI inventoryUI;

    private void Start()
    {
        // Grabs the root canvas and InventoryUI so drag/drop can work
        canvas = GetComponentInParent<Canvas>();
        inventoryUI = GetComponentInParent<InventoryUI>();
    }

    public void UpdateSlot(Item item)
    {
        currentItem = item;
        itemIcon.enabled = true;
        itemIcon.sprite = item.itemData.sprite;
        quantityText.text = item.quantity.ToString();
    }

    public void ClearSlot()
    {
        currentItem = null;
        itemIcon.enabled = false;
        quantityText.text = "";
    }

    public void OnSlotClicked()
    {
        if (currentItem != null)
        {
            Debug.Log("CLICKED");
            itemInfoPanel.ShowItemDescription(currentItem);
        }
    }


    // ========== DRAG AND DROP ==========
    /// <summary>
    /// I way too long trying to figure this out so ive decided to temporarily vibe code this part
    /// my brain cant make sense of it rn, will come back when i am str8 bruiser mode
    /// </summary>


    // STEP 1: Player starts dragging this slot
    public void OnBeginDrag(PointerEventData eventData)
    {
        // If this slot is empty, don't allow dragging — bail out
        if (currentItem == null) return;

        // Create a brand new GameObject to act as the floating icon
        // This is NOT the actual slot — it's a visual copy that follows the mouse
        dragIcon = new GameObject("DragIcon");

        // Parent it to the canvas so it renders on top of all UI
        dragIcon.transform.SetParent(canvas.transform, false);

        // Add an Image component and set it to this item's sprite
        Image img = dragIcon.AddComponent<Image>();
        img.sprite = currentItem.itemData.sprite;

        // IMPORTANT: raycastTarget = false means this floating image
        // won't block raycasts. Without this, OnDrop would never fire
        // because the drag icon would be "in the way" of the drop target
        img.raycastTarget = false;

        // Set the size and starting position of the floating icon
        RectTransform rect = dragIcon.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(50, 50);
        rect.position = eventData.position;

        // Fade the original icon so the player can see they're dragging it
        itemIcon.color = new Color(1, 1, 1, 0.3f);
    }

    // STEP 2: Fires every frame while dragging — move the icon to the mouse
    public void OnDrag(PointerEventData eventData)
    {
        if (dragIcon != null)
            dragIcon.transform.position = eventData.position;
    }

    // STEP 3: Player lets go of the mouse — clean up
    // This fires on the slot you DRAGGED FROM, regardless of where you dropped
    public void OnEndDrag(PointerEventData eventData)
    {
        // Destroy the floating icon — we don't need it anymore
        if (dragIcon != null)
            Destroy(dragIcon);

        // Restore the original icon's opacity back to full
        itemIcon.color = Color.white;
    }

    // STEP 4: Something was dropped ON this slot
    // This fires on the RECEIVING slot, not the one being dragged
    public void OnDrop(PointerEventData eventData)
    {
        // eventData.pointerDrag is the GameObject that was being dragged
        // We grab its InventorySlots script so we know which slot it came from
        InventorySlots sourceSlot = eventData.pointerDrag?.GetComponent<InventorySlots>();

        // If it wasn't a slot, or they dropped it on itself, ignore it
        if (sourceSlot == null || sourceSlot == this) return;

        // Grab the actual inventory list so we can rearrange items
        var items = inventoryUI.inventoryManager.inventory.currentInventoryItems;

        int sourceIndex = sourceSlot.slotIndex;
        int targetIndex = this.slotIndex;

        // CASE 1: Both slots have items — swap their positions in the list
        if (sourceIndex < items.Count && targetIndex < items.Count)
        {
            Item temp = items[sourceIndex];
            items[sourceIndex] = items[targetIndex];
            items[targetIndex] = temp;
        }

        // CASE 2: Dragging an item into an empty slot
        else if (sourceIndex < items.Count && targetIndex >= items.Count)
        {
            // Pad list with nulls up to the target slot
            while (items.Count <= targetIndex)
                items.Add(null);

            // Place item at target, clear the source
            items[targetIndex] = items[sourceIndex];
            items[sourceIndex] = null;
        }

        // Refresh the UI so all slots redraw with the new positions
        inventoryUI.RefreshUI();
    }
}