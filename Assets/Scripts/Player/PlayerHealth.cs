using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;

    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;

        Debug.Log("Player Health: " + currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log(
            "Player took " + damage +
            " damage. Health: " + currentHealth
        );

        if (currentHealth <= 0)
        {
            currentHealth = 0;

            Debug.Log("Player has no health remaining.");
        }
    }
}