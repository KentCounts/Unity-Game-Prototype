using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public PlayerHealth playerHealth;

    void Update()
    {
        if (playerHealth.IsDead())
        {
            ShowGameOver();
        }
    }

    private void ShowGameOver()
    {
        gameOverPanel.SetActive(true);

        Time.timeScale = 0f;

        enabled = false;
    }
}