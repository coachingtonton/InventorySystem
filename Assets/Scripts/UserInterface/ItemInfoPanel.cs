using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoPanel : MonoBehaviour
{
    [SerializeField] Image itemImage;
    [SerializeField] public TextMeshProUGUI itemDescription;

    public void ShowItemDescription(Item item)
    {
        //Grabs descritpion for inventory slots data 
        itemImage.sprite = item.itemData.sprite;
        itemDescription.text = item.itemData.description;
    }
}
