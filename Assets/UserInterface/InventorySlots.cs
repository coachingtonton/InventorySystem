using UnityEngine;
using UnityEngine.UI;
using TMPro;

/* This script exists to grab 
 * an item quantity and itemicon
 * itemicon is grabbed thru the items SO
 * quantity is grabbed thru item
 */
public class InventorySlots : MonoBehaviour
{
     public Image itemIcon;
     public TextMeshProUGUI quantityText;
     private Item currentItem;
    [SerializeField] ItemInfoPanel itemInfoPanel; 


    public void UpdateSlot(Item item)
    {
        //Gives ITEM DESCRition its data
        currentItem = item;

        //Grabs Items SO and quantity and hands it to the inventory slots
        itemIcon.enabled = true;
        itemIcon.sprite = item.itemData.sprite;
        quantityText.text = item.quantity.ToString();
    }

    public void ClearSlot()
    {
        // removesIcon to get rid of white background bug
        // makes text "" to replicate emtpy inventory
        currentItem = null;
        itemIcon.enabled = false;
        quantityText.text = "";
    }

    public void OnSlotClicked()
    {
        if (currentItem != null)
        {
            Debug.Log("CLICKED");
            //GIVES ITEMINFOPANEL current items Sprite and Desc
            itemInfoPanel.ShowItemDescription(currentItem);
        }
    }
}
