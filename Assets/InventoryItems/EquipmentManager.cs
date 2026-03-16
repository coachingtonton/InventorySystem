using UnityEngine;
using System.Collections;


public class EquipmentManager
{
    private Inventory inventory;
    public Item weaponSlot = null;

    public EquipmentManager(Inventory inventory)
    {
        this.inventory = inventory;
    }

    public void Equip(Item newItem)//UNEQUIPS CURRENT ITEM AND CHANGES WEAPON SLOT TO newItem
    {
        // Anytime you use the equip method it will unequip last weapon
        UnEquip();
        weaponSlot = newItem;
    }

    public void UnEquip()//REMOVES CURRENT ITEM
    {
        weaponSlot = null;
    }


    public IEnumerator AttackRoutine(GameObject gameObject)
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(.2f);
        gameObject.SetActive(false);

    }
}
