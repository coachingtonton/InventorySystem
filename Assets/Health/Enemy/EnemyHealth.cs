using UnityEngine;

public class EnemyHealth : MonoBehaviour, Idamageable
{
    [SerializeField]private int maxhealth;
    [SerializeField]private int currentHealth;

    private void Start()
    {
        currentHealth = maxhealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("EnemyHealth is" + currentHealth);

        // destroys object when health is 0
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
