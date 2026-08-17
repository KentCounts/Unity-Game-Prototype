using UnityEngine;
using TMPro;

public class PlayerHealthUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public TMP_Text healthText;

    void Update()
    {
        healthText.text =
            "HP: " +
            playerHealth.GetCurrentHealth() +
            " / " +
            playerHealth.GetMaxHealth();
    }
}