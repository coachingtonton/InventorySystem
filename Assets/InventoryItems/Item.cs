using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;


// This script exists to allow instantiation of items
// as well as a storage of quantity.
public class Item
{
    public ItemDataSO itemData;
    public int quantity;

    public Item(int quantity, ItemDataSO itemData)
    {
        this.quantity = quantity;
        this.itemData = itemData;
    }
}



