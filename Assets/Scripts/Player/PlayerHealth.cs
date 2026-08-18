using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;

    private int currentHealth;
    private bool dead = false;

    void Start()
    {
        currentHealth = maxHealth;

        Debug.Log("Player Health: " + currentHealth);
    }

    public void TakeDamage(int damage)
    {
        if (dead)
        {
            return;
        }

        currentHealth -= damage;

        Debug.Log(
            "Player took " + damage +
            " damage. Health: " + currentHealth
        );

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    private void Die()
    {
        dead = true;

        Debug.Log("Player has died.");
    }

    public bool IsDead()
    {
        return dead;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
}