using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory
{
    public Item item;

    public List<Item> currentInventoryItems = new List<Item>();


    // CHECKS IF ITEM EXISTS, IF NOT ADDS ITEM TO LIST
    // IF ITEM EXISTS, WILL CHECK IF IS STACKABLE
    // IF ITEM IS NOT STACKABLE, EXIT THE METHOD
    public void AddItem(Item newItem)
    {
        // LISTS OFF ALL ITEMS IN INVENTORY 
        // If item Data doesent exist, skips if statement
        // AND ADDS ITEM TO THE LIST
        for (int i = currentInventoryItems.Count -1; i >= 0; i--)
        {
            // Checks if new itemdata exists in current list
            if (currentInventoryItems[i].itemData == newItem.itemData)
            {   
                // IF ITEM already exists then Check if is stackable
                if (currentInventoryItems[i].itemData.isStackable == true)
                {
                    // IF ITEM IS STACKABLE ADD 1
                    currentInventoryItems[i].quantity += 1;
                }
            
            // AND PROCEEDS TO ADD ITEM to list
            return; 
            }
        }
        currentInventoryItems.Add(newItem);
    }

    // Method for using Consumables
    // Checks if data is the same && Quantity>0 
    // If data is the same Removes argued amount
    public void ConsumeItem(int amount, Item consumableItem)
    {
        // LISTS OFF ALL ITEMS IN INVENTORY 
        for (int i = currentInventoryItems.Count - 1; i >= 0; i--)
        {
            //CHECKS IF SAME DATA TYPE
            if (currentInventoryItems[i].itemData == consumableItem.itemData)
            {
                // CHECKS IF QUANTITY IS MORE THAN ZERO
                if (currentInventoryItems[i].quantity > 0 )
                {
                    // IF QUANITY IS MORE THAN ZERO SUBTRACT AMOUNT
                    currentInventoryItems[i].quantity -= amount;
                    return;
                }
            }
        }
    }

    // Method for removing UNSTACKABLE items
    // Checks if data is same and if item IS NOT stackable
    // Removes item from list of inventory Items
    public void RemoveItem(Item desiredRemovableitem)
    {
        // LISTS OFF ALL ITEMS IN INVENTORY 
        for (int i = currentInventoryItems.Count - 1; i >= 0; i--)
        {
            // Checks if ItemData is the Same && CHECKS if it ISNT stackable
            if (currentInventoryItems[i].itemData == desiredRemovableitem.itemData &&
                !currentInventoryItems[i].itemData.isStackable)
            {
                // REMOVES 1 FROM ITEM QUANTITY
                currentInventoryItems[i].quantity -= 1;

                // REMOVES ITEM FROM INVENTORY LIST
                currentInventoryItems.Remove(currentInventoryItems[i]);
                return;
            }
        }
    }
}
