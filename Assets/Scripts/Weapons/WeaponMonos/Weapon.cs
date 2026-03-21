using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int weaponDamage;
    public int attackSpeed;
    public int energyCost;
    public ItemDataSO weaponData;

    public void SetWeaponDamage(int passedWeaponDamage)
    {
        weaponDamage = passedWeaponDamage;
    }

    public abstract void Attack();

    private void OnTriggerEnter2D(Collider2D other)
    {
        Idamageable target = other.GetComponent<Idamageable>();
        {
            if (target != null)
            {
                target.TakeDamage(weaponDamage);
            }
        }
    }
}
