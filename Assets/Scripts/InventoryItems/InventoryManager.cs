using UnityEngine;

/* ORDER OF THIS SCRIPT
 * READ DAMAGE FIELDS FROM EQUIPED ITEMS SO'S
 * PASS THE NEEDED INFO TO THE CURRENTEQUIPPED WEAPON SCRIPT
 * TELL THE WEAPON TO ATTACK 
 */
public class InventoryManager : MonoBehaviour
{
    /* TO DO
     * rename weaponData to itemData*/


    // SO REFRENCES
    [SerializeField] ItemDataSO potionSO;
    [SerializeField] ItemDataSO swordSO;
    [SerializeField] ItemDataSO pistolSO;


    // COMPONENTS
    private Rigidbody2D rb;
    private InputCHECKERFUCK inputChecker;

    // SYSTEMS
    public Inventory inventory;
    EquipmentManager equipmentManager;

    // CURRENT weapon MONOType
    // Equipment manager functions on data 
    Weapon equippedWeaponMono;
    // inventory manager assigns the Monos to the Equipped types

    // ITEMS
    public Item potion;
    public Item sword;
    public Item pistol;

    // ARRAYS
    Weapon[] weaponMonos;

    private void Awake()
    {
        inventory = new Inventory();
        equipmentManager = new EquipmentManager(this.inventory);
    }

    private void Start()
    {
        ListofCommands();

        rb = GetComponent<Rigidbody2D>();
        inputChecker = GetComponent<InputCHECKERFUCK>();
        EventManager.current.OnItemPickedUp += PickupItem;

        // ITEM CONSTRUCTION
        pistol = new Item(1, pistolSO);
        potion = new Item(1, potionSO);
        sword = new Item(1, swordSO);

        // TEMPROARY inventory item fill
        for (int i = 0; i < 3; i++)
        {
            inventory.AddItem(pistol);
            inventory.AddItem(potion);
            inventory.AddItem(sword);
        }

        // when equipping weapons, the EQUIP method only has access to data types
        // this array stores each WeaponType Script on player. each Weapon Scrikpt has correlating weapondata
        /// Weapon Script array -> if equippedWeapon data == weaponScript.weaponData
        // if newly equipped weapon shares same weapondata THEN the monobehaviour for EQUIPED will be switched
        weaponMonos = GetComponentsInChildren<Weapon>(true);
    }

    private void Update()
    {
        ConsumePotion();
        RemoveSword();
        CheckListItems();
        DropPotion();
        EquipWeapons();
        Attack();
    }

    private void ListofCommands()
    {
        Debug.Log("Press G to consume potion");
        Debug.Log("Press R to CHECK ITEMS");
        Debug.Log("Press H to REMOVE SWORD");
        Debug.Log("Press T to DROP POTION");
        Debug.Log("Press 1 to equipSWOOOORD ");
    }

    
    private void CheckListItems()
    {   
        if (inputChecker.rKeyPressed)
        {
            foreach (Item item in inventory.currentInventoryItems)
            {
                Debug.Log(item.itemData.itemName + " x " + item.quantity);
            }
        }
    }

    public void PickupItem( ItemDataSO pickupsItemData, int quanity)
    {
        Item pickupItem = new Item(quanity, pickupsItemData);
        inventory.AddItem(pickupItem);
    }

    private void RemoveSword()
    {
        if (inputChecker.hKeyPressed)
        {
            inventory.RemoveItem(sword);
            Debug.Log(sword.quantity);
        }
    }

    private void DropPotion()
    {
        if (inputChecker.tKeyPressed && potion.quantity > 0)
        {
            inventory.ConsumeItem(1, potion);
            GameObject dropped = Instantiate(potion.itemData.dropPrefab, transform.position + new Vector3(1f, 0, 0), Quaternion.identity);
            Rigidbody2D DroppedRB = dropped.GetComponent<Rigidbody2D>();
            DroppedRB.AddForce(rb.linearVelocity * 2f, ForceMode2D.Impulse);
        }
    }

    private void ConsumePotion()
    {
        if (inputChecker.gKeyPressed)
        {
            inventory.ConsumeItem(1, potion);
            Debug.Log(potion.quantity);
        }
    }

    private void EquipWeapons()
    {
        if (inputChecker.oneKeyPressed)
        {
            equipmentManager.Equip(sword);
            FindWeaponDataType();
            Debug.Log(equipmentManager.weaponSlot.itemData.itemName);
        }
        if (inputChecker.twoKeyPressed)
        {
            equipmentManager.Equip(pistol);
            FindWeaponDataType();
            Debug.Log(equipmentManager.weaponSlot.itemData.itemName);
        }
    }

    private void Attack()
    {
        // This method checks if hotkey is pressed and inventory != null
        // method Sets weapon damage based off equipped SO 
        // method also runs equipped weapons ATTACK method
        if (inputChecker.ePressed && equipmentManager.weaponSlot != null)
        {
            Debug.Log("PLAYER USED THE " + equipmentManager.weaponSlot.itemData.itemName);

            // Variable that Stores CURRENTLY EQUIPPED WEAPONS' SO's damage amount
            int damage = equipmentManager.weaponSlot.itemData.damage;

            // Sends the Damage variable to SETWEAPONDAMAGE
            // All weapons monobehvaviours have setweapondamage And Attack
            // This is polymorphism 
            equippedWeaponMono.SetWeaponDamage(damage);
            equippedWeaponMono.Attack();
        }
    }

    private void FindWeaponDataType()
    {
        // cycles thru all weaponMonos inside player
        foreach (Weapon weapon in weaponMonos)
        {
            // if Newly equipped item shares SAME SO as a weapon Mono
            // then that Mono becomes the active equipped weapon
            if (weapon.weaponData == equipmentManager.weaponSlot.itemData)
            {
                equippedWeaponMono = weapon;
            }
        }
    }

}