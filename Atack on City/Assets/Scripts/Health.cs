using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public UnityEvent<int, int> onDamage;
    public UnityEvent onDeath;
    public bool destroyOnDeath = true;

    private int health;

    private void Start()
    {
        health = maxHealth;
    }

    public void DealDamage(int damage)
    {
        health -= damage;
        onDamage.Invoke(health, maxHealth);
        if (health <= 0)
        {
            onDeath.Invoke();
            if (destroyOnDeath)
            {
                Destroy(gameObject);
            }
        }
    }
}
