using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public int bulletDamage;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        //MAKES linear velocity travel right
        rb.linearVelocity = transform.right * bulletSpeed;

        //Destroys bullet after 3 seconds
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Idamageable isDamageable = other.GetComponent<Idamageable>();

        if (isDamageable != null)
        {
            isDamageable.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        
    }

}
