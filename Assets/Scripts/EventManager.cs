using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;

    private void Awake()
    {
        current = this;
    }

    // Events
    public event Action OnInventoryChanged;
    public event Action<ItemDataSO, int> OnItemPickedUp;
    public event Action<int> OnSlotSelected;
    public event Action<ItemDataSO, int> OnItemAssigendToHotbar;

    public event Action OnHotbarChanged;

    public void TriggerInventoryChange()
    {
        OnInventoryChanged?.Invoke();
    }

    public void TriggerItemPickedUp(ItemDataSO data, int qty)
    {
        OnItemPickedUp?.Invoke(data, qty);
    }

    public void TriggerSlotSelected(int index)
    {
        Debug.Log("EventManager firing OnSlotSelected: " + index);
        OnSlotSelected?.Invoke(index);
    }

    public void TriggerHotbarChanged()
    {
        OnHotbarChanged?.Invoke();
    }

    public void OnItemAssigendToToolbar(ItemDataSO itemData, int quantity)
    {
        OnItemAssigendToHotbar?.Invoke(itemData, quantity);
    }
}