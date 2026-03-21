using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public Item item;
    public event Action OnInventoryChanged;

    // This list now supports NULLS — a null entry means an empty slot
    // This lets players drag items to any slot position, leaving gaps
    public List<Item> currentInventoryItems = new List<Item>();


    // CHECKS IF ITEM EXISTS, IF NOT ADDS ITEM TO LIST
    // IF ITEM EXISTS, WILL CHECK IF IS STACKABLE
    // IF ITEM IS NOT STACKABLE, EXIT THE METHOD
    public void AddItem(Item newItem)
    {
        // LISTS OFF ALL ITEMS IN INVENTORY 
        // If item Data doesent exist, skips if statement
        // AND ADDS ITEM TO THE LIST
        for (int i = currentInventoryItems.Count - 1; i >= 0; i--)
        {
            // Skip null slots — they're empty gaps from drag and drop
            if (currentInventoryItems[i] == null) continue;

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
                OnInventoryChanged?.Invoke();
                return;
            }
        }

        // Before appending to the end, check if there's an empty (null) slot
        // This fills gaps left by drag and drop instead of always growing the list
        for (int j = 0; j < currentInventoryItems.Count; j++)
        {
            if (currentInventoryItems[j] == null)
            {
                currentInventoryItems[j] = newItem;
                OnInventoryChanged?.Invoke();
                return;
            }
        }

        // No existing match and no empty slots — add to the end
        currentInventoryItems.Add(newItem);
        OnInventoryChanged?.Invoke();
    }

    // Method for using Consumables
    // Checks if data is the same && Quantity>0 
    // If data is the same Removes argued amount
    public void ConsumeItem(int amount, Item consumableItem)
    {
        // LISTS OFF ALL ITEMS IN INVENTORY 
        for (int i = currentInventoryItems.Count - 1; i >= 0; i--)
        {
            // Skip null slots
            if (currentInventoryItems[i] == null) continue;

            // CHECKS IF SAME DATA TYPE
            if (currentInventoryItems[i].itemData == consumableItem.itemData)
            {
                // CHECKS IF QUANTITY IS MORE THAN ZERO
                if (currentInventoryItems[i].quantity > 0)
                {
                    // IF QUANITY IS MORE THAN ZERO SUBTRACT AMOUNT
                    currentInventoryItems[i].quantity -= amount;
                    OnInventoryChanged?.Invoke();
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
            // Skip null slots
            if (currentInventoryItems[i] == null) continue;

            // Checks if ItemData is the Same && CHECKS if it ISNT stackable
            if (currentInventoryItems[i].itemData == desiredRemovableitem.itemData &&
                !currentInventoryItems[i].itemData.isStackable)
            {
                // REMOVES 1 FROM ITEM QUANTITY
                currentInventoryItems[i].quantity -= 1;

                // Sets slot to null instead of removing it from the list
                // This preserves slot positions so drag and drop doesn't break
                currentInventoryItems[i] = null;
                OnInventoryChanged?.Invoke();
                return;
            }
        }
    }
}