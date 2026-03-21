using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class HotbarSlotUI : MonoBehaviour, IDropHandler
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI quantityText;
    [SerializeField] private Image background;

    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color selectedColor = Color.yellow;

    public void Start()
    {
        itemIcon.enabled = false;
    }

    public void UpdateSlot(Item item)
    {
        itemIcon.enabled = true;
        itemIcon.sprite = item.itemData.sprite;
        quantityText.text = item.quantity.ToString();
    }

    public void ClearSlot()
    {
        itemIcon.enabled = false;
        itemIcon.sprite = null;
        quantityText.text = "";
    }

    public void SetHighlight(bool isSelected)
    {
        background.color = isSelected ? selectedColor : normalColor;
    }

    public void OnDrop(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}