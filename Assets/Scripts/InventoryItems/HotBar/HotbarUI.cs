using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HotbarUI : MonoBehaviour
{
    [SerializeField] private HotBarManager hotbarManager;
    private HotbarSlotUI[] slots;

    private void Start()
    {
        Debug.Log("EventManager.current is: " + EventManager.current);
        slots = GetComponentsInChildren<HotbarSlotUI>();
        EventManager.current.OnHotbarChanged += RefreshUI;
        EventManager.current.OnSlotSelected += HighlightSlot;
        RefreshUI();
    }

    private void OnDestroy()
    {
        EventManager.current.OnHotbarChanged -= RefreshUI;
        EventManager.current.OnSlotSelected -= HighlightSlot;
    }

    private void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            Item item = hotbarManager.hotbar.slots[i];
            if (item != null)
                slots[i].UpdateSlot(item);
            else
                slots[i].ClearSlot();
        }
    }

    private void HighlightSlot(int index)
    {
        Debug.Log("HighlightSlot called: " + index);
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].SetHighlight(i == index);
        }
    }
}