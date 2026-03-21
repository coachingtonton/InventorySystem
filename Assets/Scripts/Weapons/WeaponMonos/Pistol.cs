using UnityEngine;

public class Pistol : Weapon
{
    // PREFABS
    [SerializeField]public GameObject bulletPrefab;


    public override void Attack()
    {
        Instantiate(bulletPrefab, transform.position + new Vector3(1,0), Quaternion.identity);
    }
}
